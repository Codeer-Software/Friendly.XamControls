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
            return new XamDataTreeNodeDriver(AppVar, This.Nodes[index]);
        }
    }
}
