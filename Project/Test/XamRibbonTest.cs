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
    public class XamRibbonTest
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
            new WPFButtonBase(main.Dynamic()._buttonXamRibbon).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _ribbon = new XamRibbonDriver(_dlg.Dynamic()._ribbon);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestAppMenuGetItemIndex()
        {
            var item = _ribbon.ApplicationMenu.GetItem(1, 0, 0);
            item.HeaderText.Is("b-1-1");
        }

        [TestMethod]
        public void TestAppMenuGetItemText()
        {
            var item = _ribbon.ApplicationMenu.GetItem("b", "b-1", "b-1-1");
            item.HeaderText.Is("b-1-1");
        }

        [TestMethod]
        public void TestEmulateClick()
        {
            var item = _ribbon.ApplicationMenu.GetItem("b", "b-1", "b-1-1");
            ((bool)_dlg.Dynamic().b_1_1_clicked).IsFalse();
            item.EmulateClick();
            ((bool)_dlg.Dynamic().b_1_1_clicked).IsTrue();
        }

        [TestMethod]
        public void TestEmulateClickAsync()
        {
            var item = _ribbon.ApplicationMenu.GetItem("b", "b-1", "b-1-1");
            ((bool)_dlg.Dynamic().b_1_1_clicked).IsFalse();
            Async a = new Async();
            item.EmulateClick(a);
            a.WaitForCompletion();
            ((bool)_dlg.Dynamic().b_1_1_clicked).IsTrue();
        }
    }
}
