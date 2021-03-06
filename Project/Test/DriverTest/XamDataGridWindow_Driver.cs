using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamDataGridWindow")]
    public class XamDataGridWindow_Driver
    {
        public WindowControl Core { get; }
        public XamDataGridDriver _grid => new XamDataGridDriver(Core.Dynamic()._grid);

        public XamDataGridWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamDataGridWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamDataGridWindow")]
        public static XamDataGridWindow_Driver Attach_XamDataGridWindow(this WindowsAppFriend app)
            => new XamDataGridWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamDataGridWindow"));
    }
}