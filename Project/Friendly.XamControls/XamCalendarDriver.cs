using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Friendly.XamControls.Inside;
using System;
using System.Collections.Generic;

namespace Friendly.XamControls
{
    public class XamCalendarDriver : XamControlBase
    {
        public DateTime? ActiveDate { get { return This.ActiveDate; } }

        public DateTime[] SelectedDates { get { return Static.GetSelectedDates(this); } }

        public XamCalendarDriver(AppVar src) : base(src) { }

        public void EmualteChangeDate(DateTime? date)
        {
            Static.EmualteChangeDate(this, date);
        }

        public void EmualteChangeDate(DateTime? date, Async async)
        {
            Static.EmualteChangeDate(this, date, async);
        }

        static void EmualteChangeDate(dynamic calendar, DateTime? date)
        {
            calendar.Focus();
            calendar.SelectedDate = date;
            calendar.ActiveDate = date;
        }

        public void EmualteAddDate(DateTime date)
        {
            Static.EmualteAddDate(this, date);
        }

        public void EmualteAddDate(DateTime date, Async async)
        {
            Static.EmualteAddDate(this, date, async);
        }

        static void EmualteAddDate(dynamic calendar, DateTime date)
        {
            calendar.Focus();
            calendar.SelectedDates.Add(date);
            calendar.ActiveDate = date;
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
