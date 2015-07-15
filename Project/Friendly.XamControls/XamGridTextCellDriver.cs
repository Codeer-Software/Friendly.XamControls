using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamGridTextCellDriver : XamGridCellDriver
    {
        public string Text { get { return Control.IdentifyByType<TextBlock>().Text; } }

        public XamGridTextCellDriver(XamGridCellDriver cell)
            : base(cell.Grid, cell.AppVar) { }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(Grid, this, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(Grid, this, text, async);
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

    public static class XamGridTextCellDriverExtensions
    {
        public static XamGridTextCellDriver AsText(this XamGridCellDriver cell)
        {
            return new XamGridTextCellDriver(cell);
        }
    }
}
