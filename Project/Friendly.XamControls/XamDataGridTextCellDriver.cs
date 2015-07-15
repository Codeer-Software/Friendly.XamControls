using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridTextCellDriver : XamDataGridCellDriver
    {
        public string Text { get { return Control.IdentifyByType("Infragistics.Windows.Editors.XamTextEditor").Text; } }

        public XamDataGridTextCellDriver(XamDataGridCellDriver cell)
            : base(cell.Grid, cell.AppVar) { }

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
            dynamic textBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamTextEditor").Single();
            textBox.Text = text;
            cell.EndEditMode(true, false);
        }
    }

    public static class XamDataGridTextCellDriverExtensions
    {
        public static XamDataGridTextCellDriver AsText(this XamDataGridCellDriver cell)
        {
            return new XamDataGridTextCellDriver(cell);
        }
    }
}
