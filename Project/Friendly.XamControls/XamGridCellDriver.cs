using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamGridCellDriver : XamControlBase
    {
        public XamGridDriver Grid { get; private set; }

        public bool IsActive { get { return This.IsActive; } }

        protected AppVar Control
        {
            get
            {
                Static.ScrollCellIntoView(Grid, this);
                return This.Control;
            }
        }

        internal XamGridCellDriver(XamGridDriver grid, AppVar cell)
            : base(cell)
        {
            Grid = grid;
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(Grid, this);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(Grid, this, async);
        }

        protected static void EmulateActivate(dynamic grid, dynamic cell)
        {
            grid.Focus();
            grid.ActiveCell = cell;
        }

        protected static void ScrollCellIntoView(dynamic grid, dynamic cell)
        {
            grid.ScrollCellIntoView(cell);
            InvokeUtility.DoEvents();
        }
    }
}
