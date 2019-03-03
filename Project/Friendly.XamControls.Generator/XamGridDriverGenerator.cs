using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Linq;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamGridDriver")]
    public class XamGridDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _control;
        
        protected override void Attach()
        {
            _control = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "ActiveCellChanged", CellActivated));
            _removes.Add(EventAdapter.Add(ControlObject, "CellExitedEditMode", EditModeEnded));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void CellActivated(object sender, dynamic e)
        {
            if (!TryGetSelectedRowCol((object)_control.ActiveCell, out var row, out var col)) return;

            AddSentence(new TokenName(),
                ".GetCell(", row, ", ", col, ").EmulateActivate(",
                new TokenAsync(CommaType.Before), ");");
        }

        void EditModeEnded(object sender, dynamic e)
        {
            if (!TryGetSelectedRowCol((object)e.Cell, out var row, out var col)) return;
            DependencyObject cellCtrl = e.Cell.Control;
            var tree = cellCtrl.VisualTree();
            var check = tree.OfType<CheckBox>().SingleOrDefault();
            if (check != null)
            {
                AddSentence(new TokenName(),
                    ".GetCell(", row, ", ", col, ").AsCheck().EmulateEdit(", GenerateUtility.ToBoolString(check.IsChecked),
                    new TokenAsync(CommaType.Before), ");");
                return;
            }

            if (e.Cell.Value == null) return;
            string text = e.Cell.Value.ToString();

            var content = tree.OfType<ContentControl>().SingleOrDefault();
            if (content != null && content.Content is ComboBox)
            { 
                AddSentence(new TokenName(),
                    ".GetCell(", row, ", ", col, ").AsCombo().EmulateEdit(", GenerateUtility.ToLiteral(text),
                    new TokenAsync(CommaType.Before), ");");
                return;
            }

            AddSentence(new TokenName(),
                ".GetCell(", row, ", ", col, ").AsText().EmulateEdit(", GenerateUtility.ToLiteral(text),
                new TokenAsync(CommaType.Before), ");");
        }

        bool TryGetSelectedRowCol(object cell, out int row, out int col)
        {
            row = ((dynamic)cell).Row.Index;
            int colCount = _control.Rows[0].Cells.Count;
            col = 0;
            for (; col < colCount; col++)
            {
                if (ReferenceEquals(_control.Rows[row].Cells[col], cell)) break;
            }
            return col < colCount;
        }
    }
}
