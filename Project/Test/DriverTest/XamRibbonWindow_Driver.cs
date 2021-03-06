using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamRibbonWindow")]
    public class XamRibbonWindow_Driver
    {
        public WindowControl Core { get; }
        public XamRibbonDriver _ribbon => new XamRibbonDriver(Core.Dynamic()._ribbon);

        public XamRibbonWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamRibbonWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamRibbonWindow")]
        public static XamRibbonWindow_Driver Attach_XamRibbonWindow(this WindowsAppFriend app)
            => new XamRibbonWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamRibbonWindow"));
    }
}