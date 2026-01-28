using StoxPlus.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Utils
{
    public static class CalendarUtils
    {
        public static DateTime DetermineFromDate(CalendarPeriod calendarPeriod)
        {
            switch (calendarPeriod)
            {
                case CalendarPeriod.LastMonth:
                    return FirstDayOfLastMonth(DateTime.Now);
                case CalendarPeriod.LastWeek:
                    return FirstDayOfLastWeek(DateTime.Now);
                case CalendarPeriod.ThisWeek:
                    return FirstDayOfWeek(DateTime.Now);
                case CalendarPeriod.ThisMonth:
                    return FirstDayOfCurrentMonth(DateTime.Now);
                case CalendarPeriod.NextWeek:
                    return FirstDayOfNextWeek(DateTime.Now);
                case CalendarPeriod.NextMonth:
                    return FirstDayOfNextMonth(DateTime.Now);
                default:
                    throw new InvalidOperationException("Calendar Period is not allowed: " + calendarPeriod.ToString());
            }
        }

        public static DateTime DetermineToDate(CalendarPeriod calendarPeriod)
        {
            switch (calendarPeriod)
            {
                case CalendarPeriod.LastMonth:
                    return LastDayOfLastMonth(DateTime.Now);
                case CalendarPeriod.LastWeek:
                    return LastDayOfLastWeek(DateTime.Now);
                case CalendarPeriod.ThisWeek:
                    return LastDayOfWeek(DateTime.Now);
                case CalendarPeriod.ThisMonth:
                    return LastDayOfCurrentMonth(DateTime.Now);
                case CalendarPeriod.NextWeek:
                    return LastDayOfNextWeek(DateTime.Now);
                case CalendarPeriod.NextMonth:
                    return LastDayOfNextMonth(DateTime.Now);
                default:
                    throw new InvalidOperationException("Calendar Period is not allowed: " + calendarPeriod.ToString());
            }
        }

        public static DateTime CreateDateTime(DateTime date, TimeSpan time)
        {
            return date.AddHours(time.Hours).AddMinutes(time.Minutes).AddSeconds(time.Seconds);
        }
        
        public static DateTime FirstDayOfWeek(DateTime dt)
        {

            var diff = dt.DayOfWeek - DayOfWeek.Sunday;
            return dt.AddDays(-diff + 1).Date;
        }

        public static DateTime LastDayOfWeek(DateTime dt)
        {

            var diff = dt.DayOfWeek - DayOfWeek.Sunday;
            return dt.AddDays(-diff + 7).Date;
        }

        public static DateTime FirstDayOfLastWeek(this DateTime dt)
        {
            return FirstDayOfWeek(dt).AddDays(-7);
        }

        public static DateTime LastDayOfLastWeek(this DateTime dt)
        {
            return FirstDayOfWeek(dt).AddDays(-1);
        }

        public static DateTime FirstDayOfNextWeek(this DateTime dt)
        {
            return FirstDayOfWeek(dt).AddDays(7);
        }

        public static DateTime LastDayOfNextWeek(this DateTime dt)
        {
            return FirstDayOfWeek(dt).AddDays(13);
        }

        public static DateTime FirstDayOfLastMonth(this DateTime dt)
        {
            return dt.FirstDayOfCurrentMonth().AddMonths(-1).Date;
        }
        public static DateTime LastDayOfLastMonth(this DateTime dt)
        {
            return dt.FirstDayOfCurrentMonth().AddDays(-1);
        }

        public static DateTime FirstDayOfCurrentMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime LastDayOfCurrentMonth(this DateTime dt)
        {
            return dt.FirstDayOfCurrentMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfNextMonth(this DateTime dt)
        {
            return dt.FirstDayOfCurrentMonth().AddMonths(1);
        }

        public static DateTime LastDayOfNextMonth(this DateTime dt)
        {
            return dt.FirstDayOfNextMonth().AddMonths(1).AddDays(-1);
        }
    }
}
