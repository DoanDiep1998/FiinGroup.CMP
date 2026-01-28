using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.ApiLimit
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class RequestUsage //[FGFQ_PJCF_DR_RequestUsage]
    {
        public int Id { get; set; }
        public long UserID { get; set; }
        public long ServiceID { get; set; }
        public string PackageCode { get; set; }
        public int RequestCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int RecordStatusId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsHistory { get; set; }
        public bool IsLastest { get; set; } // Cờ đánh dấu xem có phải mới nhất trong cache ko  , ko phải trường trong database
    }
}