using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

namespace Friendly.XamControls
{
    public class XamTabItemDriver : XamControlBase
    {
        public bool IsSelected { get { return This.IsSelected; } }

        internal XamTabItemDriver(AppVar src) : base(src) { }

        public void EmulateClose()
        {
            Static.EmulateClose(this);
        }

        public void EmulateClose(Async async)
        {
            Static.EmulateClose(this, async);
        }

        static void EmulateClose(dynamic item)
        {
            EmulateSelect(item);

            DependencyObject dep = item;
            var button = dep.VisualTree().ByType<Button>().
                Where(e => e.Command is RoutedCommand).Select(e => new { Command = (RoutedCommand)e.Command, Button = e }).
                Where(e => e.Command.OwnerType.FullName == "Infragistics.Windows.Controls.TabItemExCommands").
                Where(e=>e.Command.Name == "Close").Single().Button;
            button.Focus();
            MethodInfo methodInfo = button.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            methodInfo.Invoke(button, new object[] { });
        }

        public void EmulateSelect()
        {
            Static.EmulateSelect(this);
        }

        public void EmulateSelect(Async async)
        {
            Static.EmulateSelect(this, async);
        }

        protected static void EmulateSelect(dynamic item)
        {
            item.Focus();
            item.IsSelected = true;
        }
    }
}
