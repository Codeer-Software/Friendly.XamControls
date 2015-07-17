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
    public class XamTabControlTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamTabControlDriver _tab;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamTabControl).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _tab = new XamTabControlDriver(_dlg.Dynamic()._tab);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestSelect()
        {
            var item = _tab.GetItem(99);
            item.EmulateSelect();
            _tab.SelectedIndex.Is(99);
        }

        [TestMethod]
        public void TestSelectAsync()
        {
            _dlg.Dynamic().ConnectSelectionChanged();
            var item = _tab.GetItem(99);
            item.EmulateSelect(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _tab.SelectedIndex.Is(99);
        }

        [TestMethod]
        public void TestClose()
        {
            var item = _tab.GetItem(99);
            item.EmulateClose();
            Visibility v = item.Dynamic().Visibility;
            v.Is(Visibility.Collapsed);
            _tab.SelectedIndex.Is(98);
        }

        [TestMethod]
        public void TestCloseAsync()
        {
            var item = _tab.GetItem(99);
            _dlg.Dynamic().ConnectTabItemClosing(item);
            item.EmulateClose(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            Visibility v = item.Dynamic().Visibility;
            v.Is(Visibility.Collapsed);
            _tab.SelectedIndex.Is(98);
        }
    }
}