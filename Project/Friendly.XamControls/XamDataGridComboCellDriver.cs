using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridComboCellDriver : XamDataGridCellDriver
    {
        public string Text { get { return Control.IdentifyByType("Infragistics.Windows.Editors.XamComboEditor").Text; } }

        public int SelectedIndex { get { return Control.IdentifyByType("Infragistics.Windows.Editors.XamComboEditor").SelectedIndex; } }

        public XamDataGridComboCellDriver(XamDataGridCellDriver cell)
            : base(cell.Grid, cell.AppVar) { }

        public void EmulateEdit(int index)
        {
            Static.EmulateEdit(Control, index);
        }

        public void EmulateEdit(int index, Async async)
        {
            Static.EmulateEdit(Control, index, async);
        }

        static void EmulateEdit(dynamic control, int index)
        {
            EmulateActivate(control);
            control.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = control;
            dynamic comboBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamComboEditor").Single();
            comboBox.SelectedIndex = index;
            control.EndEditMode(true, false);
        }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(Control, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(Control, text, async);
        }

        static void EmulateEdit(dynamic cell, string text)
        {
            EmulateActivate(cell);
            cell.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = cell;
            dynamic comboBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamComboEditor").Single();
            comboBox.Text = text;
            cell.EndEditMode(true, false);
        }
    }

    public static class XamDataGridComboCellDriverExtensions
    {
        public static XamDataGridComboCellDriver AsCombo(this XamDataGridCellDriver cell)
        {
            return new XamDataGridComboCellDriver(cell);
        }
    }
}
