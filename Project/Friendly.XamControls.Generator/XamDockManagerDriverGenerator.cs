using System;
using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamDockManagerDriver")]
    public class XamDockManagerDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _dock;
        List<dynamic> panes = new List<dynamic>();

        protected override void Attach()
        {
            _dock = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "ActivePaneChanged", ActivePaneChanged));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void ActivePaneChanged(object sender, dynamic e)
        {
            if (e.NewValue == null) return;

            AddSentence(new TokenName(), ".GetPane(" + GenerateUtility.ToLiteral(e.NewValue.Header.ToString()) + ").EmulateActivate(", new TokenAsync(CommaType.Non), ");");

            if (panes.Contains(e.NewValue)) return;
            panes.Add(e.NewValue);

            _removes.Add(EventAdapter.Add((object)e.NewValue, "Closed", (_, __) => PaneClosed((string)e.NewValue.Header.ToString())));
        }

        void PaneClosed(string text)
        {
            AddSentence(new TokenName(), ".GetPane(" + GenerateUtility.ToLiteral(text) + ").EmulateClose(", new TokenAsync(CommaType.Non), ");");
        }

        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateActivate");
        }
    }
}
