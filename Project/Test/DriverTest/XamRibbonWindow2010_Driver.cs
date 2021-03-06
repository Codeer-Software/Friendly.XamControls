using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamRibbonWindow2010")]
    public class XamRibbonWindow2010_Driver
    {
        public WindowControl Core { get; }
        public XamRibbonDriver _ribbon => new XamRibbonDriver(Core.Dynamic()._ribbon);

        public XamRibbonWindow2010_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamRibbonWindow2010_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamRibbonWindow2010")]
        public static XamRibbonWindow2010_Driver Attach_XamRibbonWindow2010(this WindowsAppFriend app)
            => new XamRibbonWindow2010_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamRibbonWindow2010"));
    }
}