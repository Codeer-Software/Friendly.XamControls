using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.XamControls;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.XamDataTreeWindow")]
    public class XamDataTreeWindow_Driver
    {
        public WindowControl Core { get; }
        public XamDataTreeDriver _tree => new XamDataTreeDriver(Core.Dynamic()._tree);

        public XamDataTreeWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class XamDataTreeWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.XamDataTreeWindow")]
        public static XamDataTreeWindow_Driver Attach_XamDataTreeWindow(this WindowsAppFriend app)
            => new XamDataTreeWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.XamDataTreeWindow"));
    }
}