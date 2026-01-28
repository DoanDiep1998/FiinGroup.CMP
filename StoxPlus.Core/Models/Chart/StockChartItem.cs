using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.Chart
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class StockChartItem
    {
        public DateTime TradingDate { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal LowestPrice { get; set; }
        public decimal TotalMatchVolume { get; set; }
        public decimal TotalMatchValue { get; set; }
        public decimal RateAdjusted { get; set; }
        public decimal OpenInterest { get; set; }
        public decimal FloorPrice { get; set; }
        public decimal CeilingPrice { get; set; }
        public decimal OpenPriceUnAdjusted { get; set; }
        public decimal ClosePriceUnAdjusted { get; set; }
        public decimal HighestPriceUnAdjusted { get; set; }
        public decimal LowestPriceUnAdjusted { get; set; }
        public decimal TotalDealVolume { get; set; }
        public decimal TotalDealValue { get; set; }
        public decimal DealValue { get; set; }
        public decimal DealVolume { get; set; }
    }

    //For adjust an adjust data
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class StockChartOhlcItem 
    {
        public DateTime T { get; set; }
        public decimal O { get; set; }
        public decimal C { get; set; }
        public decimal H { get; set; }
        public decimal L { get; set; }
        public decimal V { get; set; }
        public decimal Val { get; set; }
        //public decimal RateAdjusted { get; set; }
        //public decimal OpenInterest { get; set; }
        //public decimal Fl { get; set; }
        //public decimal Ce { get; set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class StockChartDealItem
    {
        public DateTime TradingDate { get; set; }
        public decimal DealVolume { get; set; }
        public decimal DealValue { get; set; }
    }
}