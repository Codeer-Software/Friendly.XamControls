using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;

namespace Friendly.XamControls
{
    public class XamDataGridDriver : XamControlBase
    {
        public XamDataGridDriver(AppVar src) : base(src) { }

        public XamDataGridCellDriver GetCell(int row, int col)
        {
            return new XamDataGridCellDriver(this, This.Records[row].Cells[col]);
        }
    }
}
