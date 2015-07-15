using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;

namespace Friendly.XamControls
{
    public class XamOutlookBarDriver : XamControlBase
    {
        public XamOutlookBarDriver(AppVar src) : base(src) { }

        public XamOutlookBarGroupDriver GetGroup(int index)
        {
            return new XamOutlookBarGroupDriver(This.Groups[index]);
        }
    }
}
