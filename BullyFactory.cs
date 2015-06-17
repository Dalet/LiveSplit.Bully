using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

namespace LiveSplit.Bully
{
    public class BullyFactory : IComponentFactory
    {
        public string ComponentName
        {
            get { return "Bully: Scholarship Edition"; }
        }

        public string Description
        {
            get { return "Autosplitter for Bully: Scholarship Edition"; }
        }

        public ComponentCategory Category
        {
            get { return ComponentCategory.Control; }
        }

        public IComponent Create(LiveSplitState state)
        {
            return new BullyComponent(state);
        }

        public string UpdateName
        {
            get { return this.ComponentName; }
        }

        public string UpdateURL
        {
            get { return "https://raw.githubusercontent.com/Dalet/LiveSplit.Bully/master/"; }
        }

        public Version Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version; }
        }

        public string XMLURL
        {
            get { return this.UpdateURL + "Components/update.LiveSplit.Bully.xml"; }
        }
    }
}
