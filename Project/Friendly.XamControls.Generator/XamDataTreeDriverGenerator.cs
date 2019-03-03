using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Linq;

namespace Friendly.XamControls.Generator
{
    [CaptureCodeGenerator("Friendly.XamControls.XamDataTreeDriver")]
    public class XamDataTreeDriverGenerator : CaptureCodeGeneratorBase
    {
        List<Action> _removes = new List<Action>();
        dynamic _tree;
        TextBox editorTextBox;

        protected override void Attach()
        {
            _tree = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "NodeExpansionChanging", NodeExpansionChanging));
            _removes.Add(EventAdapter.Add(ControlObject, "NodeCheckedChanged", NodeCheckedChanged));
            _removes.Add(EventAdapter.Add(ControlObject, "NodeEnteredEditMode", NodeEnteredEditMode));
            _removes.Add(EventAdapter.Add(ControlObject, "NodeExitedEditMode", NodeExitedEditMode));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void NodeCheckedChanged(object sender, dynamic e)
        {
            string getNode = GetNode(e.Node);

            bool? val = e.Node.IsChecked;
            var valText = val == null ? "null" :
                          val.Value ? "true" : "false";
            AddSentence(new TokenName(), "." + getNode + ".AsCheck().EmulateEdit(", valText, new TokenAsync(CommaType.Before), ");");
        }

        void NodeExpansionChanging(object sender, dynamic e)
        {
            string getNode = GetNode(e.Node);

            bool val = e.Node.IsExpanded;
            var valText = val ? "true" : "false";
            AddSentence(new TokenName(), "." + getNode + ".EmulateChangeExpanded(", valText, new TokenAsync(CommaType.Before), ");");
        }

        void NodeEnteredEditMode(object sender, dynamic e)
            => editorTextBox = e.Editor as TextBox;

        void NodeExitedEditMode(object sender, dynamic e)
        {
            if (editorTextBox == null) return;

            string getNode = GetNode(e.Node);
            AddSentence(new TokenName(), "." + getNode + ".AsText().EmulateEdit(", GenerateUtility.ToLiteral(editorTextBox.Text), new TokenAsync(CommaType.Before), ");");
        }

        static string GetNode(dynamic node)
        {
            var list = new List<int>();
            while (node != null)
            {
                list.Insert(0, node.Index);
                node = node.Manager.ParentNode;
            }
            return string.Join(".", list.Select(e=>"GetNode(" + e + ")"));
        }
    }
}
