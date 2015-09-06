using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Reflection;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls.Primitives;
using System.Linq;
using System.Windows.Controls;

namespace Friendly.XamControls
{
    public class XamApplicationMenuDriver : XamControlBase
    {
        public XamApplicationMenuDriver(AppVar src) : base(src) { }

        public XamToolMenuItemDriver GetItem(params int[] indices)
        {
            AppVar item = Static.GetItem(this, indices);
            return item.IsNull ? null : new XamToolMenuItemDriver(item);
        }

        static dynamic GetItem(dynamic menu, int[] indices)
        {
            OpenMenu(menu);
            DependencyObject current = menu;
            dynamic item = null;
            foreach (var index in indices)
            {
                var popupChild = current.VisualTree().ByType<Popup>().Single().Child;
                if (item != null)
                {
                    XamToolMenuItemDriver.EmulateClick(item);
                }
                var items = popupChild.VisualTree().ByType("Infragistics.Windows.Ribbon.ToolMenuItem").ToArray();
                if (items.Count() <= index)
                {
                    return null;
                }
                current = item = items[index];
            }
            return item;
        }

        public XamToolMenuItemDriver GetItem(params string[] headerTexts)
        {
            AppVar item = Static.GetItem(this, headerTexts);
            return item.IsNull ? null : new XamToolMenuItemDriver(item);
        }

        static dynamic GetItem(dynamic menu, string[] headerTexts)
        {
            OpenMenu(menu);
            DependencyObject current = menu;
            dynamic item = null;
            foreach (var text in headerTexts)
            {
                var popupChild = current.VisualTree().ByType<Popup>().Single().Child;
                if (item != null)
                {
                    XamToolMenuItemDriver.EmulateClick(item);
                }
                var items = popupChild.VisualTree().ByType("Infragistics.Windows.Ribbon.ToolMenuItem").ToArray();
                current = item = items.Where((dynamic e) => e != null && e.Header.ToString() == text).SingleOrDefault();
            }
            return item;
        }

        static void OpenMenu(dynamic menu)
        {
            menu.Focus();
            var method = menu.GetType().GetMethod("OnCreateAutomationPeer", BindingFlags.NonPublic | BindingFlags.Instance);
            var peer = method.Invoke(menu, new object[0]) as AutomationPeer;
            var expander = (IExpandCollapseProvider)peer;
            expander.Expand();
            InvokeUtility.DoEvents();
        }
    }
}
