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
            return new XamGridCellDriver(AppVar, This.Rows[row].Cells[col]);
        }
    }
}
