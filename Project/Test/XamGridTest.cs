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
    public class XamGridTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamGridDriver _grid;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start("XamApp.exe"));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamGrid).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _grid = new XamGridDriver(_dlg.Dynamic()._grid);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
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
        public void TestEmulateActivateAsync()
        {
            _dlg.Dynamic().ConnectActiveCellChanged();
            var cell = _grid.GetCell(99, 1);
            cell.EmulateActivate(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
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
        public void TestEmulateEditTextBoxAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 0).AsTextBox();
            cell.EmulateEdit("abc", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
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
        public void TestEmulateEditComboBoxTextAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 1).AsComboBox();
            cell.EmulateEdit(1, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
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
        public void TestEmulateEditComboBoxSelectedIndexAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 1).AsComboBox();
            cell.EmulateEdit("c", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.SelectedIndex.Is(2);
        }

        [TestMethod]
        public void TestEmulateEditCheckBox()
        {
            var cell = _grid.GetCell(99, 2).AsCheckBox();
            cell.EmulateEdit(false);
            cell.IsChecked.Is(false);
        }

        [TestMethod]
        public void TestEmulateEditCheckBoxAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 2).AsCheckBox();
            cell.EmulateEdit(false, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.IsChecked.Is(false);
        }
    }
}
