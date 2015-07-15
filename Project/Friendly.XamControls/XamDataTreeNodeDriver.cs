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
                Static.ScrollNodeIntoView(Tree, this);
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
            ScrollNodeIntoView(tree, node);
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
            ScrollNodeIntoView(tree, node);
            InvokeUtility.DoEvents();
            node.IsExpanded = isExpanded;
        }

        static void ScrollNodeIntoView(dynamic tree, dynamic node)
        {
            tree.ScrollNodeIntoView(node);
            InvokeUtility.DoEvents();
        }
    }
}
