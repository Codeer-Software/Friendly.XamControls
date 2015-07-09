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
        public AppVar XamGrid { get; private set; }

        public bool IsActive { get { return this.Dynamic().IsActive; } }

        protected AppVar Control { get { return this.Dynamic().Control; } }

        internal XamGridCellDriver(AppVar grid, AppVar cell)
            : base(cell)
        {
            XamGrid = grid;
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(XamGrid, this);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(XamGrid, this, async);
        }

        protected static void EmulateActivate(dynamic grid, dynamic cell)
        {
            grid.Focus();
            grid.ActiveCell = cell;
            grid.ScrollCellIntoView(cell);
        }
    }
}
