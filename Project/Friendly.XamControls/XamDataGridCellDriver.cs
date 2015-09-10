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
        internal AppVar Cell { get; private set; }

        public XamDataGridDriver Grid { get; private set; }

        public bool IsActive { get { return This.IsActive; } }

        public XamDataGridCellDriver(XamDataGridDriver grid, AppVar cell, AppVar ctrl)
            : base(ctrl) 
        {
            Grid = grid;
            Cell = cell;
        }

        public XamDataGridCellDriver(XamDataGridCellDriver cell)
            : this(cell.Grid, cell.Cell, cell.AppVar)
        {
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(Cell, this);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(Cell, this, async);
        }

        protected static void EmulateActivate(dynamic cell, dynamic control)
        {
            control.Focus();
            cell.IsSelected = true;
            control.IsActive = true;

            //_grid.Dynamic().Records[99].Cells[0].IsSelected
        }
    }
}
