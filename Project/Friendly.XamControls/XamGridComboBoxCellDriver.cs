using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamGridComboBoxCellDriver : XamGridCellDriver
    {
        public string Text { get { return Control.IdentifyByType<ComboBox>().Text; } }

        public int SelectedIndex { get { return Control.IdentifyByType<ComboBox>().SelectedIndex; } }

        public XamGridComboBoxCellDriver(XamGridCellDriver cell)
            : base(cell.XamGrid, cell.AppVar) { }

        public void EmulateEdit(int index)
        {
            Static.EmulateEdit(XamGrid, this, index);
        }

        public void EmulateEdit(int index, Async async)
        {
            Static.EmulateEdit(XamGrid, this, index, async);
        }

        static void EmulateEdit(dynamic grid, dynamic cell, int index)
        {
            EmulateActivate(grid, cell);
            grid.EnterEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = grid.ActiveCell.Control;
            var comboBox = ctrl.VisualTree().ByType<ComboBox>().Single();
            comboBox.SelectedIndex = index;
            grid.ExitEditMode(false);
        }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(XamGrid, this, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(XamGrid, this, text, async);
        }

        static void EmulateEdit(dynamic grid, dynamic cell, string text)
        {
            EmulateActivate(grid, cell);
            grid.EnterEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = grid.ActiveCell.Control;
            var textBox = ctrl.VisualTree().ByType<ComboBox>().Single();
            textBox.Text = text;
            grid.ExitEditMode(false);
        }
    }

    public static class XamGridComboBoxCellDriverExtensions
    {
        public static XamGridComboBoxCellDriver AsComboBox(this XamGridCellDriver cell)
        {
            return new XamGridComboBoxCellDriver(cell);
        }
    }
}
