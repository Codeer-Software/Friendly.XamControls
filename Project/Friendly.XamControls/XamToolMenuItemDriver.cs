using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Reflection;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace Friendly.XamControls
{
    public class XamToolMenuItemDriver : XamControlBase
    {
        public AppVar Header { get { return This.Header; } }

        public string HeaderText { get { return AppVar.IsNull ? string.Empty : Header.ToString(); } }

        internal XamToolMenuItemDriver(AppVar src) : base(src) { }

        public void EmulateClick()
        {
            Static.EmulateClick(this);
        }

        public void EmulateClick(Async async)
        {
            Static.EmulateClick(this, async);
        }

        internal static void EmulateClick(dynamic item)
        {
            item.Focus();
            var method = item.GetType().GetMethod("OnCreateAutomationPeer", BindingFlags.NonPublic | BindingFlags.Instance);
            var peer = method.Invoke(item, new object[0]) as AutomationPeer;
            IInvokeProvider invoker = (IInvokeProvider)peer;
            invoker.Invoke();
            InvokeUtility.DoEvents();
        }
    }
}
