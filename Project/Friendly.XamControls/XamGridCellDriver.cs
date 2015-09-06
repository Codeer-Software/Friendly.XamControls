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
        public AppVar CellData { get; private set; }
        public bool IsActive { get { return CellData.Dynamic().IsActive; } }

        public XamGridCellDriver(XamGridDriver grid, AppVar cellData)
            : base((AppVar)cellData.Dynamic().Control)
        {
            Grid = grid;
            CellData = cellData;
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(Grid, CellData);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(Grid, CellData, async);
        }

        protected static void EmulateActivate(dynamic grid, dynamic cellData)
        {
            grid.Focus();
            grid.ActiveCell = cellData;
        }
    }
}
