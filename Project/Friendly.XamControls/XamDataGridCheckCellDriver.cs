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
            : base(cell) { }

        public void EmulateEdit(bool? check)
        {
            Static.EmulateEdit(Cell, this, check);
        }

        public void EmulateEdit(bool? check, Async async)
        {
            Static.EmulateEdit(Cell, this, check, async);
        }

        static void EmulateEdit(dynamic cell, dynamic control, bool? check)
        {
            EmulateActivate(cell, control);
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
