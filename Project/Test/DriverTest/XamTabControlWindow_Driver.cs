using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamTabControlWindow")]
    public class XamTabControlWindow_Driver
    {
        public WindowControl Core { get; }
        public XamTabControlDriver _tab => new XamTabControlDriver(Core.Dynamic()._tab);

        public XamTabControlWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamTabControlWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamTabControlWindow")]
        public static XamTabControlWindow_Driver Attach_XamTabControlWindow(this WindowsAppFriend app)
            => new XamTabControlWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamTabControlWindow"));
    }
}