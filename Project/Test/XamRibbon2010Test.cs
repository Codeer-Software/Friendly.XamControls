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
    public class XamRibbon2010Test
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamRibbonDriver _ribbon;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamRibbon2010).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _ribbon = new XamRibbonDriver(_dlg.Dynamic()._ribbon);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestTab()
        {
            _ribbon.SelectedTabIndex.Is(0);
            _ribbon.EmulateSelectTab(1);
            _ribbon.SelectedTabIndex.Is(1);
        }

        [TestMethod]
        public void TestTabAsync()
        {
            _dlg.Dynamic().ConnectRibbonTabItemSelected();
            _ribbon.EmulateSelectTab(1, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _ribbon.SelectedTabIndex.Is(1);
        }

        [TestMethod]
        public void ApplicationMenu2010Open()
        {
            var menu = _ribbon.ApplicationMenu2010;
            menu.IsOpen.IsFalse();
            menu.EmulateOpen();
            menu.IsOpen.IsTrue();
        }


        [TestMethod]
        public void ApplicationMenu2010OpenAsync()
        {
            _dlg.Dynamic().ConnectApplicationMenu2010Opened();
            var menu = _ribbon.ApplicationMenu2010;
            menu.EmulateOpen(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            menu.IsOpen.IsTrue();
        }

        [TestMethod]
        public void ApplicationMenu2010Close()
        {
            var menu = _ribbon.ApplicationMenu2010;
            menu.EmulateOpen();
            menu.IsOpen.IsTrue();
            menu.EmulateClose();
            menu.IsOpen.IsFalse();
        }

        [TestMethod]
        public void ApplicationMenu2010CloseAsync()
        {
            _dlg.Dynamic().ConnectApplicationMenu2010Closed();
            var menu = _ribbon.ApplicationMenu2010;
            menu.EmulateOpen();
            menu.IsOpen.IsTrue();
            menu.EmulateClose(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            menu.IsOpen.IsFalse();
        }

        [TestMethod]
        public void ApplicationMenu2010SelectTab()
        {
            var menu = _ribbon.ApplicationMenu2010;
            menu.EmulateOpen();
            menu.SelectedTabIndex.Is(1);
            menu.EmulateSelectTab(2);
            menu.SelectedTabIndex.Is(2);
        }

        [TestMethod]
        public void ApplicationMenu2010SelectTabAsync()
        {
            var menu = _ribbon.ApplicationMenu2010;
            menu.EmulateOpen();
            menu.SelectedTabIndex.Is(1);
            var a = new Async();
            menu.EmulateSelectTab(2, a);
            a.WaitForCompletion();
            menu.SelectedTabIndex.Is(2);
        }

        [TestMethod]
        public void ApplicationMenu2010ItemClick()
        {
            var menu = _ribbon.ApplicationMenu2010;
            menu.EmulateOpen();
            menu.SelectedTabIndex.Is(1);
            menu.GetItem(2).EmulateClick();
            menu.SelectedTabIndex.Is(2);
        }

        [TestMethod]
        public void ApplicationMenu2010ItemClickAsync()
        {
            _dlg.Dynamic().ConnectApplicationMenu2010Item2Clicked();
            var menu = _ribbon.ApplicationMenu2010;
            menu.EmulateOpen();
            menu.SelectedTabIndex.Is(1);
            menu.GetItem(2).EmulateClick(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            menu.SelectedTabIndex.Is(2);
        }
    }
}

