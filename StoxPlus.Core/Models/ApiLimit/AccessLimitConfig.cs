using ProtoBuf;
using System.Collections.Generic;

namespace StoxPlus.Core.Models.ApiLimit
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class UserLimit
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long ServiceID { get; set; }
        public int? RequestQuota { get; set; }
        public string RateLimitQuota { get; set; } = null;
        public string PackageCode { get; set; }
        public int? EodTickerQuota { get; set; } // giới hạn số lượng ticker tối đa được truy cập theo dữ liệu EOD : ví dụ =40 => chỉ được set tối đa 40 cổ phiếu
        public int? HistoricalRealtimeQuota { get; set; } // giới hạn số lượng ticker tối đa được truy cập theo dữ liệu EOD (Freequency < 1d) ví dụ =40 => chỉ được set tối đa 40 cổ phiếu
        public int? RealtimeConnQuota { get; set; }
        public int? RealtimeTickerQuota { get; set; }
        public IEnumerable<UserLimitTicker> TickerLimits { get; set; } = null;
        public IEnumerable<UserLimitTimeframe> TimeframeLimits { get; set; } = null;
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class UserLimitExtent
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long ServiceID { get; set; }
        public int? RequestQuota { get; set; }
        public string RateLimitQuota { get; set; } = null;
        public List<UserPackages> UserPackages { get; set; }
    }
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class UserPackages
    {
        public string PackageCode { get; set; }
        public int? EodTickerQuota { get; set; } // giới hạn số lượng ticker tối đa được truy cập theo dữ liệu EOD : ví dụ =40 => chỉ được set tối đa 40 cổ phiếu
        public int? HistoricalRealtimeQuota { get; set; } // giới hạn số lượng ticker tối đa được truy cập theo dữ liệu EOD (Freequency < 1d) ví dụ =40 => chỉ được set tối đa 40 cổ phiếu
        public int? RealtimeConnQuota { get; set; }
        public int? RealtimeTickerQuota { get; set; }
        public IEnumerable<UserLimitTicker> TickerLimits { get; set; } = null;
        public IEnumerable<UserLimitTimeframe> TimeframeLimits { get; set; } = null;
    }
}

[ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
public class UserLimitTicker
{
    public long UserID { get; set; }
    public string PackageCode { get; set; }
    public string Ticker { get; set; }
    public string TickerType { get; set; }
    public int DataType { get; set; } //0: Historical hoặc 1: RealTime
}

[ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
public class UserLimitTimeframe
{
    public long UserID { get; set; }
    public string PackageCode { get; set; }
    public string Timeframe { get; set; }
    public int? DaysToNow { get; set; }
    public int DataType { get; set; } //0: Historical hoặc 1: RealTime
}
