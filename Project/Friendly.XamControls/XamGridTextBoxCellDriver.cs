using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamGridTextBoxCellDriver : XamGridCellDriver
    {
        public string Text { get { return Control.IdentifyByType<TextBlock>().Text; } }

        public XamGridTextBoxCellDriver(XamGridCellDriver cell)
            : base(cell.XamGrid, cell.AppVar) { }

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
            var textBox = ctrl.VisualTree().ByType<TextBox>().Single();
            textBox.Text = text;
            grid.ExitEditMode(false);
        }
    }

    public static class XamGridTextBoxCellDriverExtensions
    {
        public static XamGridTextBoxCellDriver AsTextBox(this XamGridCellDriver cell)
        {
            return new XamGridTextBoxCellDriver(cell);
        }
    }
}
