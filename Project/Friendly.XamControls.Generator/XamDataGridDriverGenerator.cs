using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamDataGridDriver")]
    public class XamDataGridDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _control;

        static Type TextEditorBaseType = ReflectionAccessor.GetType("Infragistics.Windows.Editors.TextEditorBase");
        static Type XamCheckEditorType = ReflectionAccessor.GetType("Infragistics.Windows.Editors.XamCheckEditor");
        static Type XamComboEditorType = ReflectionAccessor.GetType("Infragistics.Windows.Editors.XamComboEditor");
        
        protected override void Attach()
        {
            _control = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "CellActivated", CellActivated));
            _removes.Add(EventAdapter.Add(ControlObject, "EditModeEnded", EditModeEnded));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void CellActivated(object sender, dynamic e)
        {
            int row = e.Cell.Record.Index;
            int col = e.Cell.Field.Index;
            AddSentence(new TokenName(),
                ".GetCell(", row, ", ", col, ").EmulateActivate(",
                new TokenAsync(CommaType.Before), ");");
        }

        void EditModeEnded(object sender, dynamic e)
        {
            if (!e.ChangesAccepted) return;

            int row = e.Cell.Record.Index;
            int col = e.Cell.Field.Index;

            var editorType = e.Editor.GetType();

            if (XamComboEditorType.IsAssignableFrom(editorType))
            {
                AddSentence(new TokenName(),
                    ".GetCell(", row, ", ", col, ").AsCombo().EmulateEdit(", GenerateUtility.ToLiteral((string)e.Editor.Text),
                    new TokenAsync(CommaType.Before), ");");
            }
            else if (XamCheckEditorType.IsAssignableFrom(editorType))
            {
                AddSentence(new TokenName(),
                    ".GetCell(", row, ", ", col, ").AsCheck().EmulateEdit(", GenerateUtility.ToBoolString((bool?)e.Editor.IsChecked),
                    new TokenAsync(CommaType.Before), ");");
            }
            else if (TextEditorBaseType.IsAssignableFrom(editorType))
            {
                AddSentence(new TokenName(),
                    ".GetCell(", row, ", ", col, ").AsText().EmulateEdit(", GenerateUtility.ToLiteral((string)e.Editor.Text),
                    new TokenAsync(CommaType.Before), ");");
            }
        }
    }
}
