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
        XamValueEditorDriver _numeric;
        XamValueEditorDriver _dateTime;
        XamValueEditorDriver _currency;
        XamValueEditorDriver _masked;
        XamValueEditorDriver _text;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamEditors).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _combo = new XamComboEditorDriver(_dlg.Dynamic()._combo);
            _numeric = new XamValueEditorDriver(_dlg.Dynamic()._numeric);
            _dateTime = new XamValueEditorDriver(_dlg.Dynamic()._dateTime);
            _currency = new XamValueEditorDriver(_dlg.Dynamic()._currency);
            _masked = new XamValueEditorDriver(_dlg.Dynamic()._masked);
            _text = new XamValueEditorDriver(_dlg.Dynamic()._text);
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

        [TestMethod]
        public void TestEmulateChangeText()
        {
            _numeric.EmulateChangeText("1234");
            _numeric.Text.Is("1,234");

            _dateTime.EmulateChangeText("1999年1月7日");
            _dateTime.Text.Is("1999年01月07日");

            _currency.EmulateChangeText("5678");
            char c = (char)165;
            _currency.Text.Is(c + "5,678");

            _masked.EmulateChangeText("abc");
            _masked.Text.Is("abc");

            _text.EmulateChangeText("efg");
            _text.Text.Is("efg");
        }

        [TestMethod]
        public void TestEmulateChangeTextAsync()
        {
            var a = new Async();
            _numeric.EmulateChangeText("1234", a);
            a.WaitForCompletion();
            _numeric.Text.Is("1,234");
        }
    }
}
