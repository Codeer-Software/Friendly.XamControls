using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataTreeCheckNodeDriver : XamDataTreeNodeDriver
    {
        public bool? IsChecked { get { return AppVar.IdentifyByType<CheckBox>().IsChecked; } }

        public XamDataTreeCheckNodeDriver(XamDataTreeNodeDriver node)
            : base(node.Tree, node.NodeData) { }

        public void EmulateEdit(bool? check)
        {
            Static.EmulateEdit(Tree, NodeData, check);
        }

        public void EmulateEdit(bool? check, Async async)
        {
            Static.EmulateEdit(Tree, NodeData, check, async);
        }

        static void EmulateEdit(dynamic tree, dynamic node, bool? check)
        {
            EmulateActivate(tree, node);
            DependencyObject ctrl = node.Control;
            dynamic checkBox = ctrl.VisualTree().ByType<CheckBox>().Single();
            checkBox.IsChecked = check;
        }
    }

    public static class XamDataTreeCheckNodeDriverExtensions
    {
        public static XamDataTreeCheckNodeDriver AsCheck(this XamDataTreeNodeDriver node)
        {
            return new XamDataTreeCheckNodeDriver(node);
        }
    }
}
