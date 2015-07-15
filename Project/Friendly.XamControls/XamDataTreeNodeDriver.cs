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
        public XamDataTreeDriver Tree { get; private set; }

        public AppVar NodeData { get; private set; }

        public bool IsActive { get { return NodeData.Dynamic().IsActive; } }

        public bool IsExpanded { get { return NodeData.Dynamic().IsExpanded; } }

        internal XamDataTreeNodeDriver(XamDataTreeDriver tree, AppVar nodeData)
            : base((AppVar)nodeData.Dynamic().Control)
        {
            Tree = tree;
            NodeData = nodeData.Dynamic();
        }

        public XamDataTreeNodeDriver GetNode(int index)
        {
            var node = NodeData.Dynamic().Nodes[index];
            Static.ScrollNodeIntoView(Tree, node);
            return new XamDataTreeNodeDriver(Tree, node);
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(Tree, NodeData);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(Tree, NodeData, async);
        }

        protected static void EmulateActivate(dynamic tree, dynamic node)
        {
            node.Control.Focus();
            node.IsActive = true;
        }

        public void EmulateChangeExpanded(bool isExpanded)
        {
            Static.EmulateChangeExpanded(Tree, NodeData, isExpanded);
        }

        public void EmulateChangeExpanded(bool isExpanded, Async async)
        {
            Static.EmulateChangeExpanded(Tree, NodeData, isExpanded, async);
        }

        static void EmulateChangeExpanded(dynamic tree, dynamic node, bool isExpanded)
        {
            node.IsExpanded = isExpanded;
        }

        static void ScrollNodeIntoView(dynamic tree, dynamic node)
        {
            tree.ScrollNodeIntoView(node);
            InvokeUtility.DoEvents();
        }
    }
}
