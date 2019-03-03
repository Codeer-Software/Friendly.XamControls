using System;
using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamTabControlDriver")]
    public class XamTabControlDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _tab;
        int _colosingIndex;

        protected override void Attach()
        {
            _tab = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "SelectionChanged", SelectionChanged));

            for (int i = 0; i < _tab.Items.Count; i++)
            {
                var item = _tab.ItemContainerGenerator.ContainerFromIndex(i);
                _removes.Add(EventAdapter.Add((object)item, "Closing", ItemClosing));
                _removes.Add(EventAdapter.Add((object)item, "Closed", ItemClosed));
            }
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void ItemClosing(object sender, dynamic e)
        {
            _colosingIndex = GetIndex(e.Source.DataContext);
        }

        void ItemClosed(object sender, dynamic e)
        {
            AddSentence(new TokenName(), ".GetItem(" + _colosingIndex + ").EmulateClose(", new TokenAsync(CommaType.Non), ");");
        }

        void SelectionChanged(object sender, dynamic e)
        {
            if (_tab.SelectedIndex != -1)
            {
                AddSentence(new TokenName(), ".GetItem(" + _tab.SelectedIndex + ").EmulateSelect(", new TokenAsync(CommaType.Non), ");");
            }
        }
        
        int GetIndex(object obj)
        {
            for (int i = 0; i < _tab.Items.Count; i++)
            {
                if (_tab.Items[i].Equals(obj))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
