using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamOutlookBarWindow")]
    public class XamOutlookBarWindow_Driver
    {
        public WindowControl Core { get; }
        public XamOutlookBarDriver _outlook => new XamOutlookBarDriver(Core.Dynamic()._outlook);

        public XamOutlookBarWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamOutlookBarWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamOutlookBarWindow")]
        public static XamOutlookBarWindow_Driver Attach_XamOutlookBarWindow(this WindowsAppFriend app)
            => new XamOutlookBarWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamOutlookBarWindow"));
    }
}