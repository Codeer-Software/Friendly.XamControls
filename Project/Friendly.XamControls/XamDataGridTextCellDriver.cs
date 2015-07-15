using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridTextCellDriver : XamDataGridCellDriver
    {
        public string Text { get { return AppVar.IdentifyByType("Infragistics.Windows.Editors.XamTextEditor").Text; } }

        public XamDataGridTextCellDriver(XamDataGridCellDriver cell)
            : base(cell.Grid, cell.AppVar) { }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(this, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(this, text, async);
        }

        static void EmulateEdit(dynamic control, string text)
        {
            EmulateActivate(control);
            control.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = control;
            dynamic textBox = ctrl.VisualTree().ByType("Infragistics.Windows.Editors.XamTextEditor").Single();
            textBox.Text = text;
            control.EndEditMode(true, false);
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
