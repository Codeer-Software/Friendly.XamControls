using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;

namespace Friendly.XamControls
{
    public class XamDataTreeDriver : XamControlBase
    {
        public XamDataTreeDriver(AppVar src) : base(src) { }

        public XamDataTreeNodeDriver GetNode(int index)
        {
            var node = This.Nodes[index];
            Static.ScrollNodeIntoView(this, node);
            return new XamDataTreeNodeDriver(this, node);
        }

        static void ScrollNodeIntoView(dynamic tree, dynamic node)
        {
            tree.ScrollNodeIntoView(node);
            InvokeUtility.DoEvents();
        }
    }
}
