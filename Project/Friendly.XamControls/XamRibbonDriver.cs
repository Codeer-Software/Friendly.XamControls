using Codeer.Friendly;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls.Inside;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Windows.Ribbon.XamRibbon")]
    public class XamRibbonDriver : XamControlBase
    {
        public int SelectedTabIndex { get { return Static.GetSelectedTabIndex(this); } }

        public XamApplicationMenuDriver ApplicationMenu { get { return new XamApplicationMenuDriver(This.ApplicationMenu); } }

        public XamApplicationMenu2010Driver ApplicationMenu2010 { get { return new XamApplicationMenu2010Driver(This.ApplicationMenu2010); } }

        public XamRibbonDriver(AppVar src) : base(src) { }

        public void EmulateSelectTab(int index)
        {
            Static.EmulateSelectTab(this, index);
        }

        public void EmulateSelectTab(int index, Async async)
        {
            Static.EmulateSelectTab(this, index, async);
        }

        static void EmulateSelectTab(dynamic ribbon, int index)
        {
            ribbon.Focus();
            ribbon.SelectedTab = ribbon.Tabs[index];
        }

        static int GetSelectedTabIndex(dynamic ribbon)
        {
            for (int i = 0; i < ribbon.Tabs.Count; i++)
            {
                if (ribbon.Tabs[i] == ribbon.SelectedTab)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
