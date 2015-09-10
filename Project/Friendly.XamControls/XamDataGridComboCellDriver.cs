using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridComboCellDriver : XamDataGridCellDriver
    {
        public string Text { get { return AppVar.IdentifyByType("Infragistics.Windows.Editors.XamComboEditor").Text; } }

        public int SelectedIndex { get { return AppVar.IdentifyByType("Infragistics.Windows.Editors.XamComboEditor").SelectedIndex; } }

        public XamDataGridComboCellDriver(XamDataGridCellDriver cell)
            : base(cell) { }

        public void EmulateEdit(int index)
        {
            Static.EmulateEdit(Cell, this, index);
        }

        public void EmulateEdit(int index, Async async)
        {
            Static.EmulateEdit(Cell, this, index, async);
        }

        static void EmulateEdit(dynamic cell, dynamic control, int index)
        {
            EmulateActivate(cell, control);
            control.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = control;
            dynamic comboBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamComboEditor").Single();
            comboBox.SelectedIndex = index;
            control.EndEditMode(true, false);
        }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(Cell, this, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(Cell, this, text, async);
        }

        static void EmulateEdit(dynamic cell, dynamic control, string text)
        {
            EmulateActivate(cell, control);
            control.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = control;
            dynamic comboBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamComboEditor").Single();
            comboBox.Text = text;
            control.EndEditMode(true, false);
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
