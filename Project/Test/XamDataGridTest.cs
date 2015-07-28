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
    public class XamDataGridTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamDataGridDriver _grid;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamDataGrid).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _grid = new XamDataGridDriver(_dlg.Dynamic()._grid);
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
            var cell = _grid.GetCell(99, 0).AsText();
            cell.EmulateEdit("abc");
            cell.Text.Is("abc");
        }

        [TestMethod]
        public void TestEmulateEditTextBoxAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 0).AsText();
            cell.EmulateEdit("abc", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.Text.Is("abc");
        }

        [TestMethod]
        public void TestEmulateEditComboBoxText()
        {
            var cell = _grid.GetCell(99, 1).AsCombo();
            cell.EmulateEdit(1);
            cell.Text.Is("b");
        }

        [TestMethod]
        public void TestEmulateEditComboBoxTextAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 1).AsCombo();
            cell.EmulateEdit(1, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.Text.Is("b");
        }

        [TestMethod]
        public void TestEmulateEditComboBoxSelectedIndex()
        {
            var cell = _grid.GetCell(99, 1).AsCombo();
            cell.EmulateEdit("c");
            cell.SelectedIndex.Is(2);
        }

        [TestMethod]
        public void TestEmulateEditComboBoxSelectedIndexAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 1).AsCombo();
            cell.EmulateEdit("c", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.SelectedIndex.Is(2);
        }

        [TestMethod]
        public void TestEmulateEditCheckBox()
        {
            var cell = _grid.GetCell(99, 2).AsCheck();
            cell.EmulateEdit(false);
            cell.IsChecked.Is(false);
        }

        [TestMethod]
        public void TestEmulateEditCheckBoxAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 2).AsCheck();
            cell.EmulateEdit(false, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.IsChecked.Is(false);
        }

        [TestMethod]
        public void TestEmulateEditDateTime()
        {
            var cell = _grid.GetCell(99, 3).AsText();
            cell.EmulateEdit("2015年01月02日");
            cell.Text.Is("2015年01月02日");
        }

        [TestMethod]
        public void TestEmulateEditDateTimeAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 3).AsText();
            cell.EmulateEdit("2015年01月02日", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.Text.Is("2015年01月02日");
        }

        [TestMethod]
        public void TestEmulateEditCurrency()
        {
            var cell = _grid.GetCell(99, 4).AsText();
            cell.EmulateEdit("123");
            cell.Text.Is((char)0xa5 + "123");
        }

        [TestMethod]
        public void TestEmulateEditCurrencyAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 4).AsText();
            cell.EmulateEdit("123", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.Text.Is((char)0xa5 + "123");
        }

        [TestMethod]
        public void TestEmulateEditNumeric()
        {
            var cell = _grid.GetCell(99, 5).AsText();
            cell.EmulateEdit("123");
            cell.Text.Is("123");
        }

        [TestMethod]
        public void TestEmulateEditNumericAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 5).AsText();
            cell.EmulateEdit("123", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.Text.Is("123");
        }

        [TestMethod]
        public void TestEmulateEditMasked()
        {
            var cell = _grid.GetCell(99, 6).AsText();
            cell.EmulateEdit("abc");
            cell.Text.Is("abc");
        }

        [TestMethod]
        public void TestEmulateEditMaskedAsync()
        {
            _dlg.Dynamic().ConnectCellExitedEditMode();
            var cell = _grid.GetCell(99, 6).AsText();
            cell.EmulateEdit("abc", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            cell.Text.Is("abc");
        }
    }
}
