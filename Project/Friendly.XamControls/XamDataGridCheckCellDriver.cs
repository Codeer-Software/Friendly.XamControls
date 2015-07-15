using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridCheckCellDriver : XamDataGridCellDriver
    {
        public bool? IsChecked { get { return AppVar.IdentifyByType("Infragistics.Windows.Editors.XamCheckEditor").IsChecked; } }

        public XamDataGridCheckCellDriver(XamDataGridCellDriver cell)
            : base(cell.Grid, cell.AppVar) { }

        public void EmulateEdit(bool? check)
        {
            Static.EmulateEdit(this, check);
        }

        public void EmulateEdit(bool? check, Async async)
        {
            Static.EmulateEdit(this, check, async);
        }

        static void EmulateEdit(dynamic control, bool? check)
        {
            EmulateActivate(control);
            control.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = control;
            dynamic checkBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamCheckEditor").Single();
            checkBox.IsChecked = check;
            control.EndEditMode(true, false);
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
