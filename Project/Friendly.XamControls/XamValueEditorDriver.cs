using Codeer.Friendly;
using Friendly.XamControls.Inside;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Windows.Editors.TextEditorBase")]
    public class XamValueEditorDriver : XamControlBase
    {
        public string Text { get { return This.Text; } }

        public XamValueEditorDriver(AppVar core) : base(core) { }

        public void EmulateChangeText(string text)
        {
            Static.EmulateChangeText(this, text);
        }

        public void EmulateChangeText(string text, Async async)
        {
            Static.EmulateChangeText(this, text, async);
        }

        static void EmulateChangeText(dynamic editor, string text)
        {
            editor.Focus();
            editor.Text = text;
        }
    }
}
