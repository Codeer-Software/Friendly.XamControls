using System;
using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamValueEditorDriver")]
    public class XamValueEditorDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _editor;

        protected override void Attach()
        {
            _editor = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "TextChanged", TextChanged));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void TextChanged(object sender, dynamic e)
        {
            AddSentence(new TokenName(), ".EmulateChangeText(", GenerateUtility.ToLiteral((string)_editor.Text), new TokenAsync(CommaType.Before), ");");
        }

        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateChangeText");
        }
    }
}
