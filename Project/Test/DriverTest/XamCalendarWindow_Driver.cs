using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamCalendarWindow")]
    public class XamCalendarWindow_Driver
    {
        public WindowControl Core { get; }
        public XamCalendarDriver _calendar => new XamCalendarDriver(Core.Dynamic()._calendar);

        public XamCalendarWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamCalendarWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamCalendarWindow")]
        public static XamCalendarWindow_Driver Attach_XamCalendarWindow(this WindowsAppFriend app)
            => new XamCalendarWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamCalendarWindow"));
    }
}