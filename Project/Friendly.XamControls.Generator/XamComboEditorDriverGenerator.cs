using System;
using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamComboEditorDriver")]
    public class XamComboEditorDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _combo;

        protected override void Attach()
        {
            _combo = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "SelectedItemChanged", SelectedItemChanged));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void SelectedItemChanged(object sender, dynamic e)
        {
            AddSentence(new TokenName(), ".EmulateChangeSelectedIndex(", _combo.SelectedIndex, new TokenAsync(CommaType.Before), ");");
        }

        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeSelectedIndex");
        }
    }
}
