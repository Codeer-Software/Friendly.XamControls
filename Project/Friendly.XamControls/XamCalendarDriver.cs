using Codeer.Friendly;
using Friendly.XamControls.Inside;
using System;
using System.Collections.Generic;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.XamControls
{
    [ControlDriver(TypeFullName = "Infragistics.Controls.Editors.XamCalendar")]
    public class XamCalendarDriver : XamControlBase
    {
        public DateTime? ActiveDate { get { return This.ActiveDate; } }

        public DateTime[] SelectedDates { get { return Static.GetSelectedDates(this); } }

        public XamCalendarDriver(AppVar src) : base(src) { }

        public void EmulateChangeDate(DateTime? date)
        {
            Static.EmulateChangeDate(this, date);
        }

        public void EmulateChangeDate(DateTime? date, Async async)
        {
            Static.EmulateChangeDate(this, date, async);
        }

        static void EmulateChangeDate(dynamic calendar, DateTime? date)
        {
            calendar.Focus();
            calendar.SelectedDate = date;
            calendar.ActiveDate = date;
        }

        public void EmulateAddDate(DateTime date)
        {
            Static.EmulateAddDate(this, date);
        }

        public void EmulateAddDate(DateTime date, Async async)
        {
            Static.EmulateAddDate(this, date, async);
        }

        public void EmulateRemoveDate(DateTime date)
        {
            Static.EmulateRemoveDate(this, date);
        }

        public void EmulateRemoveDate(DateTime date, Async async)
        {
            Static.EmulateRemoveDate(this, date, async);
        }

        static void EmulateAddDate(dynamic calendar, DateTime date)
        {
            calendar.Focus();
            calendar.BringDateIntoView(date);
            calendar.SelectedDates.Add(date);
            calendar.ActiveDate = date;
        }

        static void EmulateRemoveDate(dynamic calendar, DateTime date)
        {
            calendar.Focus();
            calendar.BringDateIntoView(date);
            calendar.SelectedDates.Remove(date);
        }

        static DateTime[] GetSelectedDates(dynamic calendar) 
        {
            var list = new List<DateTime>();
            foreach (var e in calendar.SelectedDates)
            {
                list.Add(e);
            }
            return list.ToArray();
        }
    }
}
