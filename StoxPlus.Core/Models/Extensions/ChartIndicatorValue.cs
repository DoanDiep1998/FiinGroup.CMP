using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.Extensions
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class ChartIndicatorValue
    {
        public DateTime PublicDate { get; set; }
        public decimal Value { get; set; }
        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4 { get; set; }
    }
}