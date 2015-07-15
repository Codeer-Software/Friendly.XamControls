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
    public class XamDataTreeTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamDataTreeDriver _tree;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start("XamApp.exe"));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamDataTree).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _tree = new XamDataTreeDriver(_dlg.Dynamic()._tree);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestEmulateActivate()
        {
            var node = _tree.GetNode(99).GetNode(0);
            node.IsActive.IsFalse();
            node.EmulateActivate();
            node.IsActive.IsTrue();
        }

        [TestMethod]
        public void TestEmulateActivateAsync()
        {
            _dlg.Dynamic().ConnectActiveNodeChanged();
            var node = _tree.GetNode(99).GetNode(0);
            node.EmulateActivate(new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            node.IsActive.IsTrue();
        }

        [TestMethod]
        public void TestEmulateChangeExpanded()
        {
            var node = _tree.GetNode(99);
            node.IsExpanded.IsFalse();
            node.EmulateChangeExpanded(true);
            node.IsExpanded.IsTrue();
            node.EmulateChangeExpanded(false);
            node.IsExpanded.IsFalse();
        }

        [TestMethod]
        public void TestEmulateChangeExpandedAsync()
        {
            _dlg.Dynamic().ConnectNodeExpansionChanged();
            var node = _tree.GetNode(99);
            node.EmulateChangeExpanded(true, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            node.IsExpanded.IsTrue();
        }

        [TestMethod]
        public void TestEmulateEditTextBox()
        {
            var node = _tree.GetNode(99).GetNode(0).AsText();
            node.EmulateEdit("abc");
            node.Text.Is("abc");
        }

        [TestMethod]
        public void TestEmulateEditTextBoxAsync()
        {
            _dlg.Dynamic().ConnectNodeExitedEditMode();
            var node = _tree.GetNode(99).GetNode(0).AsText();
            node.EmulateEdit("abc", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            node.Text.Is("abc");
        }

        [TestMethod]
        public void TestEmulateEditCheckBox()
        {
            var node = _tree.GetNode(99).GetNode(0).AsCheck();
            node.IsChecked.Is(false);
            node.EmulateEdit(true);
            node.IsChecked.Is(true);
        }

        [TestMethod]
        public void TestEmulateEditCheckBoxAsync()
        {
            _dlg.Dynamic().ConnectNodeCheckedChanged();
            var node = _tree.GetNode(99).GetNode(0).AsCheck();
            node.EmulateEdit(true, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            node.IsChecked.Is(true);
        }
    }
}
