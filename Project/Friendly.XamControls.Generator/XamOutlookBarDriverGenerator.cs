using System;
using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamOutlookBarDriver")]
    public class XamOutlookBarDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _outlook;

        protected override void Attach()
        {
            _outlook = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "SelectedGroupChanged", SelectedGroupChanged));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void SelectedGroupChanged(object sender, dynamic e)
        {
            var index = GetSelectedIndex();
            if (index != -1)
            {
                AddSentence(new TokenName(), ".GetGroup(" + index + ").EmulateSelect(", new TokenAsync(CommaType.Non), ");");
            }
        }

        int GetSelectedIndex()
        {
            for (int i = 0; i < _outlook.Groups.Count; i++)
            {
                if (ReferenceEquals(_outlook.SelectedGroup, _outlook.Groups[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
