using ProtoBuf;
using System;

namespace StoxPlus.Core.Models
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class SectorIndex
    {
        public string IcbCode { get; set; }
        public string ComGroupCode { get; set; }
        public DateTime TradingDate { get; set; }
        public decimal OpenIndex { get; set; }
        public decimal CloseIndex { get; set; }
        public decimal ReferenceIndex { get; set; }
        public decimal HighestIndex { get; set; }
        public decimal LowestIndex { get; set; }
        public int MatchVolume { get; set; }
        public long MatchValue { set; get; }
        public decimal IndexChange { get; set; }
        public decimal PercentIndexChange { get; set; }
        public int TotalVolume { get; set; }
        public long TotalValue { get; set; }
        public int ForeignBuyVolumeTotal { get; set; }
        public int ForeignSellVolumeTotal { get; set; }
        public long ForeignBuyValueTotal { get; set; }
        public long ForeignSellValueTotal { get; set; }
        public int TotalDealVolume { get; set; }
        public long TotalDealValue { get; set; }
        public int TotalMatchVolume { get; set; }
        public long TotalMatchValue { get; set; }
        public int DealVolume { get; set; }
        public long DealValue { get; set; }
        public short TotalStockUpPrice { get; set; }
        public short TotalStockDownPrice { get; set; }
        public short TotalStockNoChangePrice { get; set; }
        public short TotalStockUpCelling { get; set; }
        public short TotalStockDownFloor { get; set; }
        //public decimal CeilingPrice { get; set; }
        //public decimal FloorPrice { get; set; }
    }
}