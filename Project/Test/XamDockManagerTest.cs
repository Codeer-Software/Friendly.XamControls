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
    public class XamDockManagerTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamDockManagerDriver _dock;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamDockManager).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _dock = new XamDockManagerDriver(_dlg.Dynamic()._dock);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestGetPanes()
        {
            var panes = _dock.GetPanes();
            panes.Length.Is(2);
        }

        [TestMethod]
        public void TestHeader()
        {
            var panes = _dock.GetPanes();
            ((string)panes[0].Header.Core).Is("Pane1");
            panes[0].HeaderText.Is("Pane1");
        }

        [TestMethod]
        public void TestActivate()
        {
            var panes = _dock.GetPanes();
            panes[0].EmulateActivate();
            _dock.ActivePane.HeaderText.Is("Pane1");
            panes[1].EmulateActivate();
            _dock.ActivePane.HeaderText.Is("Pane2");
        }

        [TestMethod]
        public void TestActivateAsync()
        {
            var panes = _dock.GetPanes();
            panes[0].EmulateActivate();
            var async = new Async();
            panes[1].EmulateActivate(async);
            async.WaitForCompletion();
            _dock.ActivePane.HeaderText.Is("Pane2");
        }

        [TestMethod]
        public void TestVisibilityAndClose()
        {
            var panes = _dock.GetPanes();
            panes[0].Visibility.Is(Visibility.Visible);
            panes[0].EmulateClose();
            panes[0].Visibility.Is(Visibility.Collapsed);
        }

        [TestMethod]
        public void TestVisibilityAndCloseAsync()
        {
            var panes = _dock.GetPanes();
            var async = new Async();
            panes[0].EmulateClose(async);
            async.WaitForCompletion();
            panes[0].Visibility.Is(Visibility.Collapsed);
        }
    }
}
