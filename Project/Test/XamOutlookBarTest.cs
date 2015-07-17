using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.Windows;
using RM.Friendly.WPFStandardControls;
using Codeer.Friendly.Windows.Grasp;
using Friendly.XamControls;
using Codeer.Friendly.Windows.NativeStandardControls;

namespace Test
{
    [TestClass]
    public class XamOutlookBarTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamOutlookBarDriver _outlook;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamOutlookBar).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _outlook = new XamOutlookBarDriver(_dlg.Dynamic()._outlook);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void Test()
        {
            var group0 = _outlook.GetGroup(0);
            var group1 = _outlook.GetGroup(1);
            group0.IsSelected.IsTrue();
            group1.IsSelected.IsFalse();
            group1.EmulateSelect();
            group1.IsSelected.IsTrue();
        }

        [TestMethod]
        public void TestAsync()
        {
            _dlg.Dynamic().ConnectSelectedGroupChanged();
            var group = _outlook.GetGroup(1);
            group.EmulateSelect(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            group.IsSelected.IsTrue();
        }
    }
}

