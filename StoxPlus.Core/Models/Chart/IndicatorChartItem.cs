using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.Chart
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class IndicatorChartItem
    {
        public DateTime TradingDate { get; set; }
        public decimal Value { get; set; }  // Value : các loại index chỉ trả về 1 giá trị
        public decimal Value1 { get; set; } // Value1 BU , FBuy
        public decimal Value2 { get; set; } // Value2 SD , FNET
        public decimal Value3 { get; set; } // Value3 FSell
        public decimal Value4 { get; set; } // Value4 TotalForeignBuy
        public decimal Value5 { get; set; } // Value5 TotalForeignSell
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class IndicatorChartItemCommon
    {
        public DateTime TradingDate { get; set; }
        public decimal Value { get; set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class IndicatorChartItemBusd
    {
        public DateTime T { get; set; }
        public decimal B { get; set; }
        public decimal S { get; set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class IndicatorChartItemForeign
    {
        public DateTime T { get; set; }
        public decimal FB { get; set; }
        public decimal FS { get; set; }
        public decimal FN { get; set; }
        public decimal TFB { get; set; }
        public decimal TFS { get; set; }
    }
}