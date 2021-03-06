using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamDockManagerWindow")]
    public class XamDockManagerWindow_Driver
    {
        public WindowControl Core { get; }
        public XamDockManagerDriver _dock => new XamDockManagerDriver(Core.Dynamic()._dock);

        public XamDockManagerWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamDockManagerWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamDockManagerWindow")]
        public static XamDockManagerWindow_Driver Attach_XamDockManagerWindow(this WindowsAppFriend app)
            => new XamDockManagerWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamDockManagerWindow"));
    }
}