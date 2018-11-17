using Codeer.Friendly;
using Friendly.XamControls.Inside;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Windows.Controls.XamTabControl")]
    public class XamTabControlDriver : XamControlBase
    {
        public int SelectedIndex { get { return This.SelectedIndex; } }

        public int ItemCount { get { return This.Items.Count; } }

        public XamTabControlDriver(AppVar src) : base(src) { }

        public XamTabItemDriver GetItem(int index) 
        {
            var item = This.ItemContainerGenerator.ContainerFromIndex(index);
            return new XamTabItemDriver(item);
        }
    }
}
