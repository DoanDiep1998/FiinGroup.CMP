using System;

namespace StoxPlus.Infrastructure.Const
{
    public static class TradingTimeConst
    {
        public static readonly TimeSpan BeforeSession = new TimeSpan(8, 30, 0);
        public static readonly TimeSpan PreStart = new TimeSpan(8, 45, 0);
        public static readonly TimeSpan StartTime = new TimeSpan(9, 0, 15);
        public static readonly TimeSpan BreakTime = new TimeSpan(11, 30, 0);
        public static readonly TimeSpan ResumeTime = new TimeSpan(13, 0, 0);
        public static readonly TimeSpan EndTime = new TimeSpan(15, 15, 0);
        public static readonly TimeSpan BeforeProcessData = new TimeSpan(15, 30, 0);
        public static readonly TimeSpan AfterProcessData = new TimeSpan(18, 0, 0);
        public static readonly TimeSpan EndOfDay = new TimeSpan(23, 59, 59);
        public static readonly TimeSpan PriceEoDUpdated = new TimeSpan(17, 0, 0);
        public static readonly TimeSpan StartPullExchangeEoDData = new TimeSpan(15, 30, 0);
        public static readonly TimeSpan EndPullExchangeEoDData = new TimeSpan(22, 0, 0);
        public static readonly TimeSpan CollectEoDTime = new TimeSpan(16, 0, 0);
        public static readonly TimeSpan GoodMorning = new TimeSpan(6, 0, 0);
        public static readonly TimeSpan GoodEvening = new TimeSpan(19, 30, 0);

        // add for sector 
        public static readonly TimeSpan SectorEoDUpdated = new TimeSpan(20, 30, 0);
    }

    public class DataDate
    {
        public static readonly DateTime MinDate = new DateTime(2000, 1, 1);
    }
}
