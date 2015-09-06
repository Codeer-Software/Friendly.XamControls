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
    public class XamCalendarTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        XamCalendarDriver _calendar;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();
            new WPFButtonBase(main.Dynamic()._buttonXamCalendar).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _calendar = new XamCalendarDriver(_dlg.Dynamic()._calendar);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestEmulateChangeDate()
        {
            _calendar.SelectedDates.Length.Is(0);
            _calendar.EmulateChangeDate(new DateTime(2015, 7, 15));
            _calendar.ActiveDate.Is(new DateTime(2015, 7, 15));
            _calendar.SelectedDates.Length.Is(1);
            _calendar.EmulateChangeDate(new DateTime(2015, 7, 14));
            _calendar.SelectedDates.Length.Is(1);
        }

        [TestMethod]
        public void TestEmulateChangeDateAsync()
        {
            _dlg.Dynamic().ConnectSelectedDatesChanged();
            _calendar.EmulateChangeDate(new DateTime(2015, 7, 15), new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _calendar.ActiveDate.Is(new DateTime(2015, 7, 15));
        }

        [TestMethod]
        public void TestEmulateAddDate()
        {
            _calendar.EmulateChangeDate(new DateTime(2015, 7, 14));
            _calendar.EmulateAddDate(new DateTime(2015, 7, 13));
            _calendar.ActiveDate.Is(new DateTime(2015, 7, 13));
            var dates = _calendar.SelectedDates;
            dates.Length.Is(2);
            dates[0].Is(new DateTime(2015, 7, 14));
            dates[1].Is(new DateTime(2015, 7, 13));
        }

        [TestMethod]
        public void TestEmulateAddDateAsync()
        {
            _calendar.EmulateChangeDate(new DateTime(2015, 7, 15));

            _dlg.Dynamic().ConnectSelectedDatesChanged();
            _calendar.EmulateAddDate(new DateTime(2015, 7, 13), new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            var dates = _calendar.SelectedDates;
            dates.Length.Is(2);
            dates[0].Is(new DateTime(2015, 7, 15));
            dates[1].Is(new DateTime(2015, 7, 13));
        }
    }
}
