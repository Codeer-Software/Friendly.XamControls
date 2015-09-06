using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;

namespace Friendly.XamControls
{
    public class XamOutlookBarGroupDriver : XamControlBase
    {
        public bool IsSelected { get { return This.IsSelected; } }

        public XamOutlookBarGroupDriver(AppVar src) : base(src) { }

        public void EmulateSelect()
        {
            Static.EmulateSelect(this);
        }

        public void EmulateSelect(Async async)
        {
            Static.EmulateSelect(this, async);
        }

        protected static void EmulateSelect(dynamic group)
        {
            group.Focus();
            group.IsSelected = true;
        }
    }
}
