using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.ApiLimit
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class TickerUsage
    {
        public int ID { get; set; }
        public long UserID { get; set; }
        public long ServiceID { get; set; }
        public string PackageCode { get; set; }
        public string Ticker { get; set; }
        public string TickerType { get; set; } 
        public int DataType { get; set; }//TickerUsageDataType
        public long CreateBy { get; set; }
        public long UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int RecordStatusId { get; set; }
        public bool IsHistory { get; set; }
        
    }

    public enum TickerUsageDataType
    {
        HistoricalRealTime = 0,
        EOD = 10
    }
}   