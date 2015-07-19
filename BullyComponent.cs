using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.Bully
{
    class BullyComponent : LogicComponent
    {
        public override string ComponentName
        {
            get { return "Bully: Scholarship Edition"; }
        }

        public BullySettings Settings { get; set; }

        private TimerModel _timer;
        private GameMemory _gameMemory;
        private LiveSplitState _state;
        public float IGT { get; private set; }

        public BullyComponent(LiveSplitState state)
        {
            bool debug = false;
#if DEBUG
            debug = true;
#endif
            Trace.WriteLine("[NoLoads] Using LiveSplit.Bully component version " + Assembly.GetExecutingAssembly().GetName().Version + " " + ((debug) ? "Debug" : "Release") + " build");
            _state = state;
            this.Settings = new BullySettings();

            _timer = new TimerModel { CurrentState = state };

            IGT = 0;

            _gameMemory = new GameMemory();
            _gameMemory.OnTick += gameMemory_OnTick;
            _gameMemory.OnLoadStart += gameMemory_OnLoadStart;
            _gameMemory.OnLoadEnd += gameMemory_OnLoadEnd;
            state.OnStart += State_OnStart;
            _gameMemory.StartMonitoring();
        }

        public override void Dispose()
        {
            _state.OnStart -= State_OnStart;

            if (_gameMemory != null)
            {
                _gameMemory.Stop();
            }
        }

        void gameMemory_OnLoadStart(object sender, EventArgs e)
        {
            if (!this.Settings.UseIGT)
                _state.IsGameTimePaused = true;
        }

        void gameMemory_OnLoadEnd(object s, EventArgs e)
        {
            if (!this.Settings.UseIGT)
                _state.IsGameTimePaused = false;
        }

        void State_OnStart(object sender, EventArgs e)
        {
            if (this.Settings.UseIGT)
                _state.IsGameTimePaused = true;
            IGT = 0;
        }

        void gameMemory_OnTick(object sender, float time)
        {
            if (this.Settings.UseIGT && _state.CurrentPhase == TimerPhase.Running)
            {
                IGT += time;
                _state.SetGameTime(TimeSpan.FromTicks((long)(TimeSpan.TicksPerSecond * IGT)));
            }
        }

        public override XmlNode GetSettings(XmlDocument document) { return this.Settings.GetSettings(document); }

        public override Control GetSettingsControl(LayoutMode mode) { return this.Settings; }

        public override void SetSettings(XmlNode settings) { this.Settings.SetSettings(settings); }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }
    }
}
