using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridCellDriver : XamControlBase
    {
        public XamDataGridDriver Grid { get; private set; }

        public bool IsActive { get { return This.IsActive; } }

        internal XamDataGridCellDriver(XamDataGridDriver grid, AppVar cell)
            : base(cell) 
        {
            Grid = grid;
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(this);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(this, async);
        }

        protected static void EmulateActivate(dynamic control)
        {
            control.Focus();
            control.IsActive = true;
        }
    }
}
