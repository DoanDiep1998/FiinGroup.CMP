using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Enums
{
    /// <summary>
    /// En of day time frequently
    /// </summary>
    public enum TimeFrequency
    {
        Realtime,
        EachMinute,
        EachFiveMinutes,
        EachFifteenMinutes,
        EachThirtyMinutes,
        EachOneHour,
        EachTwoHours,
        EachFourHours,
        Daily,
        Weekly,
        Monthly,
        Quarterly,
        Yearly
    }
}
