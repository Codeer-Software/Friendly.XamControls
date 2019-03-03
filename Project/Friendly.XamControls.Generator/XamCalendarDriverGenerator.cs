using System;
using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamCalendarDriver")]
    public class XamCalendarDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _calendar;

        protected override void Attach()
        {
            _calendar = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "SelectedDatesChanged", SelectedDatesChanged));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void SelectedDatesChanged(object sender, dynamic e)
        {
            if (0 < e.RemovedDates.Length)
            {
                for (int i = 0; i < e.RemovedDates.Length; i++)
                {
                    DateTime? date = e.RemovedDates[i];
                    var val = date == null ? "null" :
                                "new DateTime(" + date.Value.Year + ", " + date.Value.Month + ", " + date.Value.Day + ")";
                    AddSentence(new TokenName(), ".EmulateRemoveDate(", val, new TokenAsync(CommaType.Before), ");");
                }
            }
            if (0 < e.AddedDates.Length)
            {
                for (int i = 0; i < e.AddedDates.Length; i++)
                {
                    DateTime? date = e.AddedDates[i];
                    var val = date == null ? "null" :
                                "new DateTime(" + date.Value.Year + ", " + date.Value.Month + ", " + date.Value.Day + ")";
                    AddSentence(new TokenName(), ".EmulateAddDate(", val, new TokenAsync(CommaType.Before), ");");
                }
            }
        }
    }
}
