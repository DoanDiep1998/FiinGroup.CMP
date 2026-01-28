using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Const
{
    public static class RealtimeConst
    {
        public const string TickerBucketHashKeyPostfix = "RealtimeTickers";
        public const string IndexBucketHashKey = "RealtimeIndices";
        public const string DerivativesBucketHashKey = "RealtimeDerivatives";
        public const string CoveredWarrentsBucketHashKey = "RealtimeCoveredWarrants";
        public const string BidAskBucketHashKey = "RealtimeBidAsks";
        public const string SectorBucketHashKey = "RealtimeSectors";

        public const string IndexSeriesPrefix = "RealtimeIndexSeries";
        public const string TickerSeriesPrefix = "RealtimeTickerSeries";
        public const string DerivativeSeriesPrefix = "RealtimeDerivativeSeries";
        public const string SectorSeriesPrefix = "RealtimeSectorSeries";

        public const string BidAskSeriesPrefix = "BidAskSeries";

        public const string StatisticValuePrefix = "StatisticValue";

        public const string Realtime21StepsTickerSeries = "Realtime21StepsTickerSeries";

        public const string RealtimeDealSeries = "RealtimeDealSeries";
    }
}
