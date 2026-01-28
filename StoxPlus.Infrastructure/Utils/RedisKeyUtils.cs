using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Utils
{
    public static class RedisKeyUtils
    {
        public static readonly TimeSpan ElevenHalf = new TimeSpan(11, 29, 59);
        public static readonly TimeSpan Twelve = new TimeSpan(12, 00, 00);
        public static readonly TimeSpan FourteenHalf = new TimeSpan(14, 29, 59);
        public static readonly TimeSpan FourteenHalfMinute = new TimeSpan(14, 30, 29);
        public static readonly TimeSpan Fifteen = new TimeSpan(14, 59, 59);

        public static string GetBuSdOnPriceKey(string organCode)
        {
            return $"BuSdOnPrice{organCode}";
        }

        public static string GetBuSdOnPriceHashKey(decimal matchPrice, byte matchType)
        {
            return $"{matchPrice}_{matchType}";
        }

        public static string GetBuSdRedisHash(DateTime dateTime)
        {
            return GetBuSdRedisHash(dateTime.TimeOfDay);
        }

        public static string GetBuSdRedisHash(TimeSpan time)
        {
            if (Fifteen < time)
            {
                time = Fifteen;
            }
            else if(FourteenHalf < time && time < FourteenHalfMinute)
            {
                time = FourteenHalf;
            }
            else if (ElevenHalf < time && time < Twelve)
            {
                time = ElevenHalf;
            }
            

            var timeSpan = new TimeSpan(time.Hours, (time.Minutes / 15 + 1) * 15, 0);
            return $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:00";
        }
    }
}
