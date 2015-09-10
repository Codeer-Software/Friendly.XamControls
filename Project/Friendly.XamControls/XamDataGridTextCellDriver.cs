using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridTextCellDriver : XamDataGridCellDriver
    {
        public string Text { get { return This.Editor.Text; } }

        public XamDataGridTextCellDriver(XamDataGridCellDriver cell)
            : base(cell) {}

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
            control.Editor.Text = text;
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
