using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.ApiLimit
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class TimeFrameUsage
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public string TimeFrame { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedBy { get; set; }
    }
}