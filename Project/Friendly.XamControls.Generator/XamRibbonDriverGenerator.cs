using System;
using System.Collections.Generic;
using System.Linq;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamRibbonDriver")]
    public class XamRibbonDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _ribbon;
        int tabOldSelectedIndex;
        protected override void Attach()
        {
            _ribbon = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "RibbonTabItemSelected", RibbonTabItemSelected));
            tabOldSelectedIndex = GetSelectedTabIndex();
            if (_ribbon.ApplicationMenu2010 != null)
            {
                _removes.Add(EventAdapter.Add((object)_ribbon.ApplicationMenu2010, "Opened", ApplicationMenu2010Opened));
                _removes.Add(EventAdapter.Add((object)_ribbon.ApplicationMenu2010, "Closed", ApplicationMenu2010Closed));

                for (int i = 0; i < _ribbon.ApplicationMenu2010.Items.Count; i++)
                {
                    var index = i;
                    var item = _ribbon.ApplicationMenu2010.Items[i];
                    _removes.Add(EventAdapter.Add((object)item, "Click", (_,__)=>XamRibbonWindow2010ItemClick(index)));
                }
            }
            if (_ribbon.ApplicationMenu != null)
            {
                AttachEvent(_ribbon.ApplicationMenu.Items, new string[0]);
            }
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void AttachEvent(dynamic items, string[] path)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var nextPath = path.Concat(new[] { (string)item.Header.ToString() }).ToArray();
                if (0 < item.Items.Count)
                {
                    AttachEvent(item.Items, nextPath);
                }
                else
                {
                    _removes.Add(EventAdapter.Add((object)item, "Click", (_, __) => ApplicationMenuItemClick(nextPath)));
                }
            }
        }

        void ApplicationMenuItemClick(string[] path)
        {
            var args = string.Join(", ", path.Select(e => GenerateUtility.ToLiteral(e)));
            AddSentence(new TokenName(), ".ApplicationMenu.GetItem(", args, ").EmulateClick(", new TokenAsync(CommaType.Non), ");");
        }

        void RibbonTabItemSelected(object sender, dynamic e)
        {
            var index = GetSelectedTabIndex();
            if (index != -1 && tabOldSelectedIndex != index)
            {
                AddSentence(new TokenName(), ".EmulateSelectTab(", index, new TokenAsync(CommaType.Before), ");");
            }
            tabOldSelectedIndex = index;
        }

        void ApplicationMenu2010Opened(object sender, dynamic e)
        {
            AddSentence(new TokenName(), ".ApplicationMenu2010.EmulateOpen(", new TokenAsync(CommaType.Non), ");");
        }

        void ApplicationMenu2010Closed(object sender, dynamic e)
        {
            AddSentence(new TokenName(), ".ApplicationMenu2010.EmulateClose(", new TokenAsync(CommaType.Non), ");");
        }

        void XamRibbonWindow2010ItemClick(int index)
        {
            AddSentence(new TokenName(), ".ApplicationMenu2010.GetItem(", index, ").EmulateClick(", new TokenAsync(CommaType.Non), ");");
        }

        int GetSelectedTabIndex()
        {
            for (int i = 0; i < _ribbon.Tabs.Count; i++)
            {
                if (_ribbon.Tabs[i] == _ribbon.SelectedTab)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
