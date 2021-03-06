using Codeer.Friendly.Dynamic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Test.DriverTest
{
    [WindowDriver(TypeFullName = "XamApp.MainWindow")]
    public class MainWindow_Driver
    {
        public WindowControl Core { get; }
        public WPFButtonBase _buttonXamGrid => new WPFButtonBase(Core.Dynamic()._buttonXamGrid);
        public WPFButtonBase _buttonXamDataGrid => new WPFButtonBase(Core.Dynamic()._buttonXamDataGrid);
        public WPFButtonBase _buttonXamRibbon2010 => new WPFButtonBase(Core.Dynamic()._buttonXamRibbon2010);
        public WPFButtonBase _buttonXamRibbon => new WPFButtonBase(Core.Dynamic()._buttonXamRibbon);
        public WPFButtonBase _buttonXamDataTree => new WPFButtonBase(Core.Dynamic()._buttonXamDataTree);
        public WPFButtonBase _buttonXamOutlookBar => new WPFButtonBase(Core.Dynamic()._buttonXamOutlookBar);
        public WPFButtonBase _buttonXamCalendar => new WPFButtonBase(Core.Dynamic()._buttonXamCalendar);
        public WPFButtonBase _buttonXamDockManager => new WPFButtonBase(Core.Dynamic()._buttonXamDockManager);
        public WPFButtonBase _buttonXamTabControl => new WPFButtonBase(Core.Dynamic()._buttonXamTabControl);
        public WPFButtonBase _buttonXamEditors => new WPFButtonBase(Core.Dynamic()._buttonXamEditors);

        public MainWindow_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class MainWindow_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "XamApp.MainWindow")]
        public static MainWindow_Driver Attach_MainWindow(this WindowsAppFriend app)
            => new MainWindow_Driver(app.WaitForIdentifyFromTypeFullName("XamApp.MainWindow"));
    }
}