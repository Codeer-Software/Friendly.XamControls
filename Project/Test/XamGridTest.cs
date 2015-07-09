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

namespace Test
{
    [TestClass]
    public class XamGridTest
    {
        WindowsAppFriend app;
        XamGridDriver _grid;

        [TestInitialize]
        public void TestInitialize()
        {
            app = new WindowsAppFriend(Process.Start("XamApp.exe"));
            var main = WindowControl.FromZTop(app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamGrid).EmulateClick(a);
            var next = main.WaitForNextModal();
            _grid = new XamGridDriver(next.Dynamic()._grid);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestEmulateActivate()
        {
            var cell = _grid.GetCell(99, 1);
            cell.IsActive.IsFalse();
            cell.EmulateActivate();
            cell.IsActive.IsTrue();
        }

        [TestMethod]
        public void TestEmulateEditTextBox()
        {
            var cell = _grid.GetCell(99, 0).AsTextBox();
            cell.EmulateEdit("abc");
            cell.Text.Is("abc");
        }
        [TestMethod]
        public void TestEmulateEditComboBoxText()
        {
            var cell = _grid.GetCell(99, 1).AsComboBox();
            cell.EmulateEdit(1);
            cell.Text.Is("b");
        }
        [TestMethod]
        public void TestEmulateEditComboBoxSelectedIndex()
        {
            var cell = _grid.GetCell(99, 1).AsComboBox();
            cell.EmulateEdit("c");
            cell.SelectedIndex.Is(2);
        }

        [TestMethod]
        public void TestEmulateEditCheckBox()
        {
            var cell = _grid.GetCell(99, 2).AsCheckBox();
            cell.EmulateEdit(false);
            cell.IsChecked.Is(false);
        }
    }
}
