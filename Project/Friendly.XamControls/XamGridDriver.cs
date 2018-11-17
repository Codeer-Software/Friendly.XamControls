using Codeer.Friendly;
using Friendly.XamControls.Inside;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Controls.Grids.XamGrid")]
    public class XamGridDriver : XamControlBase
    {
        public XamGridDriver(AppVar src) : base(src) { }

        public XamGridCellDriver GetCell(int row, int col)
        {
            var cellData = This.Rows[row].Cells[col];
            Static.ScrollCellIntoView(this, cellData);
            return new XamGridCellDriver(this, cellData);
        }

        static void ScrollCellIntoView(dynamic grid, dynamic cell)
        {
            grid.ScrollCellIntoView(cell);
            InvokeUtility.DoEvents();
        }
    }
}
