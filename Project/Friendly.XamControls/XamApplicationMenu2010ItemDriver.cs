using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace Friendly.XamControls
{
    public class XamApplicationMenu2010ItemDriver : XamControlBase
    {
        public AppVar Header { get { return This.Header; } }

        public string HeaderText { get { return AppVar.IsNull ? string.Empty : Header.ToString(); } }

        public XamApplicationMenu2010ItemDriver(AppVar src) : base(src) { }

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
