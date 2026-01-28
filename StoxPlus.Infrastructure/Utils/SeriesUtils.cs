using StoxPlus.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Utils
{
    public static class SeriesUtils
    {
        public static int DetermineIntervalInMinutes(TimeRange timeRange)
        {
            switch (timeRange)
            {
                case TimeRange.Realtime:
                    return 0;
                case TimeRange.OneDay:
                    return 1;
                case TimeRange.OneWeek:
                    return 5;
                case TimeRange.TwoWeeks:
                    return 10;
                case TimeRange.ThreeWeeks:
                    return 15;
                case TimeRange.OneMonth:
                    return 30;
                case TimeRange.TwoMonths:
                    return 60;
                case TimeRange.ThreeMonths:
                    return 90;
                case TimeRange.SixMonths:
                    return 180;
                case TimeRange.NineMonths:
                    return 270;
                case TimeRange.YearToDate:
                    return (DateTime.Now - new DateTime(DateTime.Now.Year, 1, 1)).Days;
                case TimeRange.OneYear:
                    return 365;
                case TimeRange.TwoYears:
                    return 365 * 2;
                case TimeRange.ThreeYears:
                    return 365 * 3;
                case TimeRange.FiveYears:
                    return 365 * 5;
                case TimeRange.TenYears:
                    return 365 * 10;
                default:
                    throw new InvalidOperationException("TimeRange is not allowed: " + timeRange.ToString());
            }
        }

        public static DateTime DetermineFromDate(TimeRange timeRange)
        {
            switch (timeRange)
            {
                case TimeRange.Realtime:
                    return DateTime.Now.Date;
                case TimeRange.OneWeek:
                    return DateTime.Now.AddDays(-7).Date;
                case TimeRange.TwoWeeks:
                    return DateTime.Now.AddDays(-14).Date;
                case TimeRange.ThreeWeeks:
                    return DateTime.Now.AddDays(-21).Date;
                case TimeRange.OneMonth:
                    return DateTime.Now.AddMonths(-1).Date;
                case TimeRange.TwoMonths:
                    return DateTime.Now.AddMonths(-2).Date;
                case TimeRange.ThreeMonths:
                    return DateTime.Now.AddMonths(-3).Date;
                case TimeRange.SixMonths:
                    return DateTime.Now.AddMonths(-6).Date;
                case TimeRange.NineMonths:
                    return DateTime.Now.AddMonths(-9).Date;
                case TimeRange.YearToDate:
                    return new DateTime(DateTime.Now.Year, 1, 1);
                case TimeRange.OneYear:
                    return DateTime.Now.Date.AddYears(-1);
                case TimeRange.TwoYears:
                    return DateTime.Now.Date.AddYears(-2);
                case TimeRange.ThreeYears:
                    return DateTime.Now.Date.AddYears(-3);
                case TimeRange.FiveYears:
                    return DateTime.Now.Date.AddYears(-5);
                case TimeRange.TenYears:
                    return DateTime.Now.Date.AddYears(-10);
                case TimeRange.AllTime:
                    return new DateTime(1970, 1, 1);
                default:
                    throw new InvalidOperationException("TimeRange is not allowed: " + timeRange.ToString());
            }
        }

        public static int DetermineNoOfWorkingDays(TimeRange timeRange)
        {
            switch(timeRange)
            {
                case TimeRange.Realtime:
                    return 0;
                case TimeRange.OneDay:
                    return 1;
                case TimeRange.OneWeek:
                    return 5;
                case TimeRange.TwoWeeks:
                    return 10;
                case TimeRange.ThreeWeeks:
                    return 15;
                case TimeRange.OneMonth:
                    return 25;
                case TimeRange.TwoMonths:
                    return 50;
                case TimeRange.ThreeMonths:
                    return 75;
                case TimeRange.SixMonths:
                    return 150;
                case TimeRange.NineMonths:
                    return 175;
                case TimeRange.YearToDate:
                    return (int)(DateTime.Now - new DateTime(DateTime.Now.Year, 1, 1)).TotalDays;
                case TimeRange.OneYear:
                    return 313;
                case TimeRange.TwoYears:
                    return 313 * 2;
                case TimeRange.ThreeYears:
                    return 313 * 3;
                case TimeRange.FiveYears:
                    return 313 * 5;
                case TimeRange.TenYears:
                    return 3130;
                case TimeRange.AllTime:
                    return 99999;
                default:
                    throw new InvalidOperationException("TimeRange is not allowed: " + timeRange.ToString());
            }
        }

        public static int DeterminIntervalInMinutes(TimeInterval timeInterval)
        {
            switch (timeInterval) {
                case TimeInterval.OneMinute:
                    return 1;
                case TimeInterval.FiveMintues:
                    return 5;
                case TimeInterval.FifteenMinutes:
                    return 15;
                case TimeInterval.ThirteenMinutes:
                    return 30;
                case TimeInterval.OneHour:
                    return 60;
                default:
                    throw new InvalidOperationException("Invalid TimeInterval: " + timeInterval.ToString());
            }
        }

        public static int DetermineIntervalInMinutes(TimeFrequency frequency)
        {
            switch (frequency)
            {
                case TimeFrequency.EachMinute:
                    return 1;
                case TimeFrequency.EachFiveMinutes:
                    return 5;
                case TimeFrequency.EachFifteenMinutes:
                    return 15;
                case TimeFrequency.EachThirtyMinutes:
                    return 30;
                case TimeFrequency.EachOneHour:
                    return 60;
                case TimeFrequency.Daily:
                    return 420;
                case TimeFrequency.Weekly:
                    return 7680;
                case TimeFrequency.Monthly:
                    return 42480;
                case TimeFrequency.Quarterly:
                    return 128880;
                case TimeFrequency.Yearly:
                    return 524880;
                default:
                    throw new InvalidOperationException("Invalid TimeFrequently: " + frequency.ToString());
            }
        }
    }
}
