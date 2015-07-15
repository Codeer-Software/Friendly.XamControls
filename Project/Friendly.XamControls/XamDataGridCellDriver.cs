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

        protected AppVar Control 
        {
            get
            {
                Grid.Dynamic().BringRecordIntoView(This.Record);
                return App.Type().Infragistics.Windows.DataPresenter.CellValuePresenter.FromCell(AppVar);
            }
        }

        internal XamDataGridCellDriver(XamDataGridDriver grid, AppVar cell)
            : base(cell) 
        {
            Grid = grid;
        }

        public void EmulateActivate()
        {
            Static.EmulateActivate(Control);
        }

        public void EmulateActivate(Async async)
        {
            Static.EmulateActivate(Control, async);
        }

        protected static void EmulateActivate(dynamic cell)
        {
            cell.Focus();
            cell.IsActive = true;
        }
    }
}
