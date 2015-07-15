using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridCheckCellDriver : XamDataGridCellDriver
    {
        public bool? IsChecked { get { return Control.IdentifyByType("Infragistics.Windows.Editors.XamCheckEditor").IsChecked; } }

        public XamDataGridCheckCellDriver(XamDataGridCellDriver cell)
            : base(cell.Grid, cell.AppVar) { }

        public void EmulateEdit(bool? check)
        {
            Static.EmulateEdit(Control, check);
        }

        public void EmulateEdit(bool? check, Async async)
        {
            Static.EmulateEdit(Control, check, async);
        }

        static void EmulateEdit(dynamic cell, bool? check)
        {
            EmulateActivate(cell);
            cell.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = cell;
            dynamic checkBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamCheckEditor").Single();
            checkBox.IsChecked = check;
            cell.EndEditMode(true, false);
        }
    }

    public static class XamDataGridCheckCellDriverExtensions
    {
        public static XamDataGridCheckCellDriver AsCheck(this XamDataGridCellDriver cell)
        {
            return new XamDataGridCheckCellDriver(cell);
        }
    }
}
