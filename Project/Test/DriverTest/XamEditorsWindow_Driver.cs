using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamEditorsWindow")]
    public class XamEditorsWindow_Driver
    {
        public WindowControl Core { get; }
        public XamComboEditorDriver _combo => new XamComboEditorDriver(Core.Dynamic()._combo);
        public XamValueEditorDriver _numeric => new XamValueEditorDriver(Core.Dynamic()._numeric);
        public XamValueEditorDriver _dateTime => new XamValueEditorDriver(Core.Dynamic()._dateTime);
        public XamValueEditorDriver _currency => new XamValueEditorDriver(Core.Dynamic()._currency);
        public XamValueEditorDriver _masked => new XamValueEditorDriver(Core.Dynamic()._masked);
        public XamValueEditorDriver _text => new XamValueEditorDriver(Core.Dynamic()._text);

        public XamEditorsWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamEditorsWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamEditorsWindow")]
        public static XamEditorsWindow_Driver Attach_XamEditorsWindow(this WindowsAppFriend app)
            => new XamEditorsWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamEditorsWindow"));
    }
}