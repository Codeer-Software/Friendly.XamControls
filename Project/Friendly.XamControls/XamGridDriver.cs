using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;

namespace Friendly.XamControls
{
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
