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
            var cell = This.Records[row].Cells[col];
            This.BringCellIntoView(cell);
            App.Type(typeof(InvokeUtility)).DoEvents();
            var ctrl = App.Type().Infragistics.Windows.DataPresenter.CellValuePresenter.FromCell(cell);
            return new XamDataGridCellDriver(this, cell, ctrl);
        }
    }
}
