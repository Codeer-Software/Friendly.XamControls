using Codeer.Friendly;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls.Inside;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Windows.OutlookBar.XamOutlookBar")]
    public class XamOutlookBarDriver : XamControlBase
    {
        public XamOutlookBarDriver(AppVar src) : base(src) { }

        public XamOutlookBarGroupDriver GetGroup(int index)
        {
            return new XamOutlookBarGroupDriver(This.Groups[index]);
        }
    }
}
