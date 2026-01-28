using StoxPlus.Core.Models.TIKMarket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoxPlus.Core.Calculators
{
    public static class StockTechnicalIndicatorCalculator
    {
        public static decimal CalculateRSI(IEnumerable<PriceModel> items)
        {
            if(!items.Any(i => i.PriceChange < 0))
            {
                return 100;
            }

            if(!items.Any(i => i.PriceChange > 0))
            {
                return 0;
            }

            var up = items.Where(i => i.PriceChange > 0).Average(i => i.PriceChange);
            var down = items.Where(i => i.PriceChange < 0).Average(i => Math.Abs(i.PriceChange));
            var rs = up / down;
            return 100 * rs / (1 + rs);
        }

        public static decimal CalculateCMF(IEnumerable<PriceModel> items)
        {
            var filtered = items.Where(i => i.HighestPrice > i.LowestPrice);
            if(!filtered.Any())
            {
                return 0;
            }
            var totalVolume = filtered.Sum(i => i.MatchVolume);
            if(totalVolume == 0)
            {
                return 0;
            }

            return filtered.Sum(i => (((GetClosePrice(i) - i.LowestPrice) - (i.HighestPrice - GetClosePrice(i))) / (i.HighestPrice - i.LowestPrice)) * i.MatchVolume) / totalVolume;
        }

        public static decimal CalculateROC(IEnumerable<PriceModel> items)
        {
            items = items.OrderByDescending(i => i.TradingDate);
            var cur = items.First();
            var last = items.Last();
            return (GetClosePrice(cur) - GetClosePrice(last)) / GetClosePrice(last);
        }

        private static decimal GetClosePrice(PriceModel i)
        {
            return i.MatchPrice == 0 ? i.ClosePrice : i.MatchPrice;
        }
    }
}
