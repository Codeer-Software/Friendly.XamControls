using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Friendly.XamControls
{
    public class XamDataGridTextCellDriverBase : XamDataGridCellDriver
    {
        string _editorName;

        public string Text { get { return AppVar.IdentifyByType(_editorName).Text; } }

        public XamDataGridTextCellDriverBase(XamDataGridCellDriver cell, string editorName)
            : base(cell.Grid, cell.AppVar) 
        {
            _editorName = editorName;
        }

        public void EmulateEdit(string text)
        {
            Static.EmulateEdit(this, _editorName, text);
        }

        public void EmulateEdit(string text, Async async)
        {
            Static.EmulateEdit(this, _editorName, text, async);
        }

        static void EmulateEdit(dynamic control, string editorName, string text)
        {
            EmulateActivate(control);
            control.StartEditMode();
            InvokeUtility.DoEvents();
            DependencyObject ctrl = control;
            dynamic textBox = ctrl.VisualTree().ByType(editorName).Single();
            textBox.Text = text;
            control.EndEditMode(true, false);
        }
    }

    public class XamDataGridTextCellDriver : XamDataGridTextCellDriverBase
    {
        public XamDataGridTextCellDriver(XamDataGridCellDriver cell)
            : base(cell, "Infragistics.Windows.Editors.XamTextEditor") { }
    }

    public class XamDataGridCurrencyCellDriver : XamDataGridTextCellDriverBase
    {
        public XamDataGridCurrencyCellDriver(XamDataGridCellDriver cell)
            : base(cell, "Infragistics.Windows.Editors.XamCurrencyEditor") { }
    }

    public class XamDataGridDateTimeCellDriver : XamDataGridTextCellDriverBase
    {
        public XamDataGridDateTimeCellDriver(XamDataGridCellDriver cell)
            : base(cell, "Infragistics.Windows.Editors.XamDateTimeEditor") { }
    }

    public class XamDataGridNumericCellDriver : XamDataGridTextCellDriverBase
    {
        public XamDataGridNumericCellDriver(XamDataGridCellDriver cell)
            : base(cell, "Infragistics.Windows.Editors.XamNumericEditor") { }
    }

    public class XamDataGridMaskedCellDriver : XamDataGridTextCellDriverBase
    {
        public XamDataGridMaskedCellDriver(XamDataGridCellDriver cell)
            : base(cell, "Infragistics.Windows.Editors.XamMaskedEditor") { }
    }

    public static class XamDataGridTextCellDriverExtensions
    {
        public static XamDataGridTextCellDriver AsText(this XamDataGridCellDriver cell)
        {
            return new XamDataGridTextCellDriver(cell);
        }
        public static XamDataGridCurrencyCellDriver AsCurrency(this XamDataGridCellDriver cell)
        {
            return new XamDataGridCurrencyCellDriver(cell);
        }
        public static XamDataGridDateTimeCellDriver AsDateTime(this XamDataGridCellDriver cell)
        {
            return new XamDataGridDateTimeCellDriver(cell);
        }
        public static XamDataGridNumericCellDriver AsNumeric(this XamDataGridCellDriver cell)
        {
            return new XamDataGridNumericCellDriver(cell);
        }
        public static XamDataGridMaskedCellDriver AsMasked(this XamDataGridCellDriver cell)
        {
            return new XamDataGridMaskedCellDriver(cell);
        }
    }
}
