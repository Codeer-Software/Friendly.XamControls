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
    public class XamEditorsTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamComboEditorDriver _combo;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamEditors).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _combo = new XamComboEditorDriver(_dlg.Dynamic()._combo);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestEmulateChangeSelectedIndex()
        {
            _combo.SelectedIndex.Is(-1);
            _combo.EmulateChangeSelectedIndex(1);
            _combo.SelectedIndex.Is(1);
        }

        [TestMethod]
        public void TestEmulateChangeSelectedIndexAsync()
        {
            _dlg.Dynamic().ConnectSelectedIndexChanged();
            _combo.EmulateChangeSelectedIndex(1, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _combo.SelectedIndex.Is(1);
        }
    }
}
