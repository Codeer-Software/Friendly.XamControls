using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace Friendly.XamControls
{
    public class XamApplicationMenu2010Driver : XamControlBase
    {
        public int SelectedTabIndex { get { return Static.GetSelectedTabIndex(this); } }

        public bool IsOpen { get { return This.IsOpen; } }

        internal XamApplicationMenu2010Driver(AppVar src) : base(src) { }

        public XamApplicationMenu2010ItemDriver GetItem(int index)
        {
            return new XamApplicationMenu2010ItemDriver(This.Items[index]);
        }

        public void EmulateOpen()
        {
            Static.EmulateChangeOpen(this, true);
        }

        public void EmulateOpen(Async async)
        {
            Static.EmulateChangeOpen(this, true, async);
        }

        public void EmulateClose()
        {
            Static.EmulateChangeOpen(this, false);
        }

        public void EmulateClose(Async async)
        {
            Static.EmulateChangeOpen(this, false, async);
        }

        static void EmulateChangeOpen(dynamic menu, bool isOpen)
        {
            menu.Focus();
            menu.IsOpen = isOpen;
        }

        public void EmulateSelectTab(int index)
        {
            Static.EmulateSelectTab(this, index);
        }

        public void EmulateSelectTab(int index, Async async)
        {
            Static.EmulateSelectTab(this, index, async);
        }

        static void EmulateSelectTab(dynamic menu, int index)
        {
            menu.Focus();
            menu.SelectedTabItem = menu.Items[index];
        }

        static int GetSelectedTabIndex(dynamic menu)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                if (menu.Items[i] == menu.SelectedTabItem)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public class XamApplicationMenu2010ItemDriver : XamControlBase
    {
        public AppVar Header { get { return This.Header; } }

        public string HeaderText { get { return AppVar.IsNull ? string.Empty : Header.ToString(); } }

        internal XamApplicationMenu2010ItemDriver(AppVar src) : base(src) { }

        public void EmulateClick()
        {
            Static.EmulateClick(this, This.OnCreateAutomationPeer());
        }

        public void EmulateClick(Async async)
        {
            Static.EmulateClick(this, This.OnCreateAutomationPeer(), async);
        }

        static void EmulateClick(dynamic item, AutomationPeer peer)
        {
            item.Focus();
            ((IInvokeProvider)peer).Invoke();
        }
    }
}
