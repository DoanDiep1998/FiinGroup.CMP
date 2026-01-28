using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models.TIKMarket
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class HnxDerivativeRealtimeModel
    {

        public string DerivativeCode { get; set; }

        public int StockNo { get; set; }

        public DateTime TradingDate { get; set; }

        public string StockType { get; set; }

        public decimal CeilingPrice { get; set; }

        public decimal FloorPrice { get; set; }

        public decimal ReferencePrice { get; set; }

        public DateTime ReferenceDate { get; set; }

        public decimal OpenPrice { get; set; }

        public decimal ClosePrice { get; set; }

        public decimal MatchPrice { get; set; }

        public decimal MatchVolume { get; set; }

        public decimal MatchValue { get; set; }

        public decimal PriceChange { get; set; }

        public decimal PercentPriceChange { get; set; }

        public decimal HighestPrice { get; set; }

        public decimal LowestPrice { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal DealVolume { get; set; }

        public decimal DealPrice { get; set; }

        public decimal TotalMatchVolume { get; set; }

        public decimal TotalMatchValue { get; set; }

        public decimal TotalDealVolume { get; set; }

        public decimal TotalDealValue { get; set; }

        public decimal TotalVolume { get; set; }

        public decimal TotalValue { get; set; }

        public decimal ForeignBuyValueMatched { get; set; }

        public decimal ForeignBuyVolumeMatched { get; set; }

        public decimal ForeignSellValueMatched { get; set; }

        public decimal ForeignSellVolumeMatched { get; set; }

        public decimal ForeignBuyValueDeal { get; set; }

        public decimal ForeignBuyVolumeDeal { get; set; }

        public decimal ForeignSellValueDeal { get; set; }

        public decimal ForeignSellVolumeDeal { get; set; }

        public decimal ForeignBuyValueTotal { get; set; }

        public decimal ForeignBuyVolumeTotal { get; set; }

        public decimal ForeignSellValueTotal { get; set; }

        public decimal ForeignSellVolumeTotal { get; set; }

        public decimal ForeignTotalRoom { get; set; }

        public decimal ForeignCurrentRoom { get; set; }

        public int Parvalue { get; set; }

        public string BoardCode { get; set; }

        public string TradingSessionId { get; set; }

        public int TradSesStatus { get; set; }

        public int SecurityTradingStatus { get; set; }

        public int ListingStatus { get; set; }

        public decimal TotalBuyTradeVolume { get; set; }

        public decimal TotalSellTradeVolume { get; set; }

        public decimal PriorOpenPrice { get; set; }

        public decimal PriorClosePrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal CurrentVolume { get; set; }

        public int TotalSellTrade { get; set; }

        public int TotalBuyTrade { get; set; }

        public decimal TotalBuyTradingVolume { get; set; }

        public int BuyCount { get; set; }

        public decimal TotalBuyTradingValue { get; set; }

        public decimal TotalSellTradingVolume { get; set; }

        public int SellCount { get; set; }

        public decimal TotalSellTradingValue { get; set; }

        public decimal TotalBidQtty_OD { get; set; }

        public decimal TotalOfferQtty_OD { get; set; }

        public string SenderCompID { get; set; }

        public decimal OpenInterest { get; set; }

        public decimal PercentOpenInterestChange { get; set; }

        public DateTime FirstTradingDate { get; set; }

        public DateTime LastTradingDate { get; set; }

        public decimal OpenMatchVolume { get; set; }

        public decimal CloseMatchVolume { get; set; }

        public string ComGroupCode { get; set; }

        public string OrganCode { get; set; }

        public string BondCode { get; set; }

        public byte MatchType { get; set; }

        public string MarketStatus { get; set; }
    }
}
