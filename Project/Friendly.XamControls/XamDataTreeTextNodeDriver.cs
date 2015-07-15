using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataTreeTextNodeDriver : XamDataTreeNodeDriver
    {
        public string Text { get { return AppVar.IdentifyByType<TextBlock>().Text; } }

        public XamDataTreeTextNodeDriver(XamDataTreeNodeDriver node)
            : base(node.Tree, node.NodeData) { }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(Tree, NodeData, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(Tree, NodeData, text, async);
        }

        static void EmulateEdit(dynamic tree, dynamic node, string text)
        {
            EmulateActivate(tree, node);
            tree.EnterEditMode(node);
            InvokeUtility.DoEvents();
            DependencyObject ctrl = node.Control;
            dynamic textBox = ctrl.VisualTree().ByType<TextBox>().Single();
            textBox.Text = text;
            tree.ExitEditMode(false);
        }
    }

    public static class XamDataTreeTextNodeDriverExtensions
    {
        public static XamDataTreeTextNodeDriver AsText(this XamDataTreeNodeDriver node)
        {
            return new XamDataTreeTextNodeDriver(node);
        }
    }

}
