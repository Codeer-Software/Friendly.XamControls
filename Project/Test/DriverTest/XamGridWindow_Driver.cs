using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamGridWindow")]
    public class XamGridWindow_Driver
    {
        public WindowControl Core { get; }
        public XamGridDriver _grid => new XamGridDriver(Core.Dynamic()._grid);

        public XamGridWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamGridWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamGridWindow")]
        public static XamGridWindow_Driver Attach_XamGridWindow(this WindowsAppFriend app)
            => new XamGridWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamGridWindow"));
    }
}