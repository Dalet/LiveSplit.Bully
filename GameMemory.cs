using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Bully
{
    class GameMemory
    {
        public const int SLEEP_TIME = 15;

        public delegate void OnTickEventHandler(object sender, float ticks);
        public event OnTickEventHandler OnTick;
        public event EventHandler OnLoadStart;
        public event EventHandler OnLoadEnd;

        private Task _thread;
        private CancellationTokenSource _cancelSource;
        private SynchronizationContext _uiThread;
        private List<int> _ignorePIDs;

        private DeepPointer _gameTimePtr;
        private DeepPointer _isLoadingPtr;

        public GameMemory()
        {
            _gameTimePtr = new DeepPointer(0x17782D8);
            _isLoadingPtr = new DeepPointer(0x7F3E34);

            _ignorePIDs = new List<int>();
        }

        public void StartMonitoring()
        {
            if (_thread != null && _thread.Status == TaskStatus.Running)
            {
                throw new InvalidOperationException();
            }
            if (!(SynchronizationContext.Current is WindowsFormsSynchronizationContext))
            {
                throw new InvalidOperationException("SynchronizationContext.Current is not a UI thread.");
            }

            _uiThread = SynchronizationContext.Current;
            _cancelSource = new CancellationTokenSource();
            _thread = Task.Factory.StartNew(MemoryReadThread);
        }

        public void Stop()
        {
            if (_cancelSource == null || _thread == null || _thread.Status != TaskStatus.Running)
            {
                return;
            }

            _cancelSource.Cancel();
            _thread.Wait();
        }
        void MemoryReadThread()
        {
            Trace.WriteLine("[NoLoads] MemoryReadThread");

            while (!_cancelSource.IsCancellationRequested)
            {
                try
                {
                    Trace.WriteLine("[NoLoads] Waiting for Bully.exe...");

                    Process game;
                    while ((game = GetGameProcess()) == null)
                    {
                        Thread.Sleep(250);
                        if (_cancelSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }

                    Trace.WriteLine("[NoLoads] Got Bully.exe!");

                    uint frameCounter = 0;
                    float prevGameTime = 0;
                    bool prevIsLoading = false;

                    while (!game.HasExited)
                    {
                        float gameTime;
                        _gameTimePtr.Deref(game, out gameTime);

                        bool isLoading;
                        _isLoadingPtr.Deref(game, out isLoading);

                        if (isLoading != prevIsLoading)
                        {
                            if (isLoading)
                            {
                                Debug.WriteLine("[NoLoads] Load start - " + frameCounter);
                                _uiThread.Post(d =>
                                {
                                    if (this.OnLoadStart != null)
                                    {
                                        this.OnLoadStart(this, EventArgs.Empty);
                                    }
                                }, null);
                            }
                            else
                            {
                                Debug.WriteLine("[NoLoads] Load end - " + frameCounter);
                                _uiThread.Post(d =>
                                {
                                    if (this.OnLoadEnd != null)
                                    {
                                        this.OnLoadEnd(this, EventArgs.Empty);
                                    }
                                }, null);
                            }
                        }

                        if (gameTime != prevGameTime && gameTime > prevGameTime)
                        {
                            var timeToAdd = gameTime - prevGameTime;
                            Debug.WriteLine("[NoLoads] Time added: " + timeToAdd + "s - " + frameCounter);
                            _uiThread.Post(d =>
                            {
                                if (this.OnTick != null)
                                {
                                    this.OnTick(this, timeToAdd);
                                }
                            }, null);
                        }

                        frameCounter++;
                        prevGameTime = gameTime;
                        prevIsLoading = isLoading;

                        Thread.Sleep(SLEEP_TIME);

                        if (_cancelSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    Thread.Sleep(1000);
                }
            }
        }

        Process GetGameProcess()
        {
            Process game = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "bully"
                && !p.HasExited && !_ignorePIDs.Contains(p.Id));
            if (game == null)
            {
                return null;
            }

            /*if (game.MainModule.ModuleMemorySize != (int)ExpectedExeSizes.steam_1_2_0)
            {
                _ignorePIDs.Add(game.Id);
                _uiThread.Send(d => MessageBox.Show("Unexpected game version.\r\n ModuleMemorySize: " + game.MainModule.ModuleMemorySize, "LiveSplit.Bully",
                    MessageBoxButtons.OK, MessageBoxIcon.Error), null);
                return null;
            }*/

            return game;
        }
    }
}
