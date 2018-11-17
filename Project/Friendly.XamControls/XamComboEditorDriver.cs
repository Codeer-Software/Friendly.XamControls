using Codeer.Friendly;
using Friendly.XamControls.Inside;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Windows.Editors.XamComboEditor")]
    public class XamComboEditorDriver : XamControlBase
    {
        public int ItemCount { get { return This.Items.Count; } }

        public int SelectedIndex { get { return This.SelectedIndex; } }

        public XamComboEditorDriver(AppVar core) : base(core) { }

        public void EmulateChangeSelectedIndex(int index)
        {
            Static.EmulateChangeSelectedIndex(this, index);
        }

        public void EmulateChangeSelectedIndex(int index, Async async)
        {
            Static.EmulateChangeSelectedIndex(this, index, async);
        }

        static void EmulateChangeSelectedIndex(dynamic combo, int index)
        {
            combo.Focus();
            combo.SelectedIndex = index;
        }
    }
}
