using ProtoBuf;
using System;

namespace StoxPlus.Core.Models
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class ComGroupIndex
    {
        public long IndexId { get; set; }
        public string ComGroupCode { get; set; }
        public decimal IndexValue { get; set; }
        public DateTime TradingDate { get; set; }
        public decimal IndexChange { get; set; }
        public decimal PercentIndexChange { get; set; }
        public decimal ReferenceIndex { get; set; }
        public decimal OpenIndex { get; set; }
        public decimal CloseIndex { get; set; }
        public decimal HighestIndex { get; set; }
        public decimal LowestIndex { get; set; }

        //public int TypeIndex { get; set; }
        public decimal TotalMatchVolume { get; set; }

        public decimal TotalMatchValue { get; set; }
        public decimal TotalDealVolume { get; set; }
        public decimal TotalDealValue { get; set; }
        public decimal TotalVolume { get; set; }
        public decimal TotalValue { get; set; }
        public int TotalStockUpPrice { get; set; }
        public int TotalStockDownPrice { get; set; }
        public int TotalStockNoChangePrice { get; set; }

        //public int TotalUpVolume { get; set; }
        //public int TotalDownVolume { get; set; }
        //public int TotalNoChangeVolume { get; set; }
        //public int TotalTrade { get; set; }
        //public int TotalBuyTrade { get; set; }
        //public decimal TotalBuyTradeVolume { get; set; }
        //public int TotalSellTrade { get; set; }
        //public decimal TotalSellTradeVolume { get; set; }
        //public decimal ForeignBuyValueMatched { get; set; }
        //public decimal ForeignBuyVolumeMatched { get; set; }
        //public decimal ForeignSellValueMatched { get; set; }
        //public decimal ForeignSellVolumeMatched { get; set; }
        //public decimal ForeignBuyValueDeal { get; set; }
        //public decimal ForeignBuyVolumeDeal { get; set; }
        //public decimal ForeignSellValueDeal { get; set; }
        //public decimal ForeignSellVolumeDeal { get; set; }
        public decimal ForeignBuyValueTotal { get; set; }

        public decimal ForeignBuyVolumeTotal { get; set; }
        public decimal ForeignSellValueTotal { get; set; }
        public decimal ForeignSellVolumeTotal { get; set; }
        public decimal ForeignTotalRoom { get; set; }
        public decimal ForeignCurrentRoom { get; set; }

        //public decimal Status { get; set; }
        public decimal TotalStockUnderFloor { get; set; }

        public decimal TotalStockOverCeiling { get; set; }
        public decimal MatchVolume { get; set; }
        public decimal MatchValue { get; set; }
        public decimal Ceiling { get; set; }
        public decimal Floor { get; set; }
        public string MarketStatus { get; set; }
    }
}