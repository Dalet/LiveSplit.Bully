using System;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.Bully
{
    public partial class BullySettings : UserControl
    {
        public bool UseIGT { get; set; }

        private const bool DEFAULT_USEIGT = false;

        public BullySettings()
        {
            InitializeComponent();

            this.rbIGT.DataBindings.Add("Checked", this, "UseIGT", false, DataSourceUpdateMode.OnPropertyChanged);

            // defaults
            this.UseIGT = DEFAULT_USEIGT;
        }


        public XmlNode GetSettings(XmlDocument doc)
        {
            XmlElement settingsNode = doc.CreateElement("Settings");

            settingsNode.AppendChild(ToElement(doc, "Version", Assembly.GetExecutingAssembly().GetName().Version.ToString(3)));
            settingsNode.AppendChild(ToElement(doc, "UseIGT", this.UseIGT));

            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            var element = (XmlElement)settings;

            this.UseIGT = ParseBool(settings, "UseIGT", DEFAULT_USEIGT);
        }

        static bool ParseBool(XmlNode settings, string setting, bool default_ = false)
        {
            bool val;
            return settings[setting] != null ?
                (Boolean.TryParse(settings[setting].InnerText, out val) ? val : default_)
                : default_;
        }

        static XmlElement ToElement<T>(XmlDocument document, string name, T value)
        {
            XmlElement str = document.CreateElement(name);
            str.InnerText = value.ToString();
            return str;
        }

    }
}
