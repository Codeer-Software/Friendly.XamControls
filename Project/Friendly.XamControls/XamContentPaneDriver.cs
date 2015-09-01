using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Windows;

namespace Friendly.XamControls
{
    public class XamContentPaneDriver : XamControlBase
    {
        public AppVar Header { get { return This.Header; } }

        public string HeaderText { get { return AppVar.IsNull ? string.Empty : Header.ToString(); } }

        public XamContentPaneDriver(AppVar src) : base(src) { }

        public void EmulateClose()
        {
            var command = App.Type().Infragistics.Windows.DockManager.ContentPaneCommands.Close;
            Static.ExecuteCommand(this, command);
        }

        public void EmulateClose(Async async)
        {
            var command = App.Type().Infragistics.Windows.DockManager.ContentPaneCommands.Close;
            Static.ExecuteCommand(this, command, async);
        }

        static void ExecuteCommand(dynamic pane, dynamic command)
        {
            pane.ExecuteCommand(command);
        }
    }
}
