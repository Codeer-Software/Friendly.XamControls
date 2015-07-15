using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataTreeNodeDriver : XamControlBase
    {
        public dynamic Tree { get; private set; }

        public AppVar Control 
        {
            get 
            {
                Tree.ScrollNodeIntoView(this);
                return This.Control; 
            }
        }
            
        public bool IsActive { get { return This.IsActive; } }

        public bool IsExpanded { get { return This.IsExpanded; } }

        internal XamDataTreeNodeDriver(AppVar tree, AppVar node) : base(node)
        {
            Tree = tree.Dynamic();
        }

        public XamDataTreeNodeDriver GetNode(int index)
        {
            return new XamDataTreeNodeDriver((AppVar)Tree, This.Nodes[index]);
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(Tree, this);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(Tree, this, async);
        }

        protected static void EmulateActivate(dynamic tree, dynamic node)
        {
            tree.ScrollNodeIntoView(node);
            InvokeUtility.DoEvents();
            node.IsActive = true;
        }

        public void EmulateChangeExpanded(bool isExpanded)
        {
            Static.EmulateChangeExpanded(Tree, this, isExpanded);
        }

        public void EmulateChangeExpanded(bool isExpanded, Async async)
        {
            Static.EmulateChangeExpanded(Tree, this, isExpanded, async);
        }

        static void EmulateChangeExpanded(dynamic tree, dynamic node, bool isExpanded)
        {
            tree.ScrollNodeIntoView(node);
            InvokeUtility.DoEvents();
            node.IsExpanded = isExpanded;
        }
    }



    public class XamDataTreeTextNodeDriver : XamDataTreeNodeDriver
    {
        public string Text { get { return Control.IdentifyByType<TextBlock>().Text; } }

        public XamDataTreeTextNodeDriver(XamDataTreeNodeDriver node)
            : base((AppVar)node.Tree, node.AppVar) { }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(Tree, this, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(Tree, this, text, async);
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













    public class XamDataTreeCheckNodeDriver : XamDataTreeNodeDriver
    {
        public bool? IsChecked { get { return Control.IdentifyByType<CheckBox>().IsChecked; } }

        public XamDataTreeCheckNodeDriver(XamDataTreeNodeDriver node)
            : base((AppVar)node.Tree, node.AppVar) { }

        public void EmulateEdit(bool? check)
        {
            Static.EmulateEdit(Tree, this, check);
        }

        public void EmulateEdit(bool? check, Async async)
        {
            Static.EmulateEdit(Tree, this, check, async);
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
