using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.TIKMarket
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class PriceModel
    {
        public string OrganCode { get; set; }

        public string ComGroupCode { get; set; }

        public string Ticker { get; set; }

        public DateTime TradingDate { get; set; }

        public decimal CeilingPrice { get; set; }

        public decimal FloorPrice { get; set; }

        private decimal _referencePrice;

        public decimal ReferencePrice
        {
            get
            {
                if (ComGroupCode == "UpcomIndex")
                {
                    return Math.Round(_referencePrice / 100) * 100;
                }
                else
                {
                    return _referencePrice;
                }
            }
            set
            {
                _referencePrice = value;
            }
        }

        public DateTime ReferenceDate { get; set; }

        public decimal OpenPrice { get; set; }

        public decimal ClosePrice { get; set; }

        public decimal MatchPrice { get; set; }

        private decimal _priceChange;

        public decimal PriceChange
        {
            get
            {
                if (ComGroupCode == "UpcomIndex")
                {
                    return Math.Round(_priceChange / 100) * 100;
                }
                else
                {
                    return _priceChange;
                }
            }
            set
            {
                _priceChange = value;
            }
        }

        private decimal _percentPriceChange { get; set; }

        public decimal PercentPriceChange
        {
            get
            {
                if (ComGroupCode == "UpcomIndex")
                {
                    return Math.Round(_percentPriceChange * 1000) / 1000;
                }
                else
                {
                    return _percentPriceChange;
                }
            }
            set
            {
                _percentPriceChange = value;
            }
        }

        public decimal HighestPrice { get; set; }

        public decimal LowestPrice { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal MatchVolume { get; set; }

        public decimal MatchValue { get; set; }

        public decimal TotalMatchVolume { get; set; }

        public decimal TotalMatchValue { get; set; }

        public decimal TotalDealVolume { get; set; }

        public decimal TotalDealValue { get; set; }

        public decimal TotalVolume { get; set; }

        public decimal TotalValue { get; set; }

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

        public decimal DealVolume { get; set; }

        public decimal DealValue { get; set; }

        public decimal DealPrice { get; set; }

        //public decimal Best1Bid { get; set; }

        //public decimal Best1BidVolume { get; set; }

        //public decimal Best1Offer { get; set; }

        //public decimal Best1OfferVolume { get; set; }

        public byte MatchType { get; set; }

        public decimal TotalBuyTradeVolume { get; set; }

        public decimal TotalSellTradeVolume { get; set; }

        public string MarketStatus { get; set; }

        public decimal RateAdjusted { get; set; }
    }

    public class PriceModelFiinQuant
    {
        public string OrganCode { get; set; }

        public string ComGroupCode { get; set; }

        public string Ticker { get; set; }

        public DateTime TradingDate { get; set; }

        public decimal CeilingPrice { get; set; }

        public decimal FloorPrice { get; set; }

        private decimal _referencePrice;

        public decimal ReferencePrice
        {
            get
            {
                if (ComGroupCode == "UpcomIndex")
                {
                    return Math.Round(_referencePrice / 100) * 100;
                }
                else
                {
                    return _referencePrice;
                }
            }
            set
            {
                _referencePrice = value;
            }
        }

        public DateTime ReferenceDate { get; set; }

        public decimal OpenPrice { get; set; }

        public decimal ClosePrice { get; set; }

        public decimal MatchPrice { get; set; }

        private decimal _priceChange;

        public decimal PriceChange
        {
            get
            {
                if (ComGroupCode == "UpcomIndex")
                {
                    return Math.Round(_priceChange / 100) * 100;
                }
                else
                {
                    return _priceChange;
                }
            }
            set
            {
                _priceChange = value;
            }
        }

        private decimal _percentPriceChange { get; set; }

        public decimal PercentPriceChange
        {
            get
            {
                if (ComGroupCode == "UpcomIndex")
                {
                    return Math.Round(_percentPriceChange * 1000) / 1000;
                }
                else
                {
                    return _percentPriceChange;
                }
            }
            set
            {
                _percentPriceChange = value;
            }
        }

        public decimal HighestPrice { get; set; }

        public decimal LowestPrice { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal MatchVolume { get; set; }

        public decimal MatchValue { get; set; }

        public decimal TotalMatchVolume { get; set; }

        public decimal TotalMatchValue { get; set; }

        public decimal TotalDealVolume { get; set; }

        public decimal TotalDealValue { get; set; }

        public decimal TotalVolume { get; set; }

        public decimal TotalValue { get; set; }

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

        public decimal DealVolume { get; set; }

        public decimal DealValue { get; set; }

        public decimal DealPrice { get; set; }

        //public decimal Best1Bid { get; set; }

        //public decimal Best1BidVolume { get; set; }

        //public decimal Best1Offer { get; set; }

        //public decimal Best1OfferVolume { get; set; }

        public byte MatchType { get; set; }

        public decimal TotalBuyTradeVolume { get; set; }

        public decimal TotalSellTradeVolume { get; set; }

        public string MarketStatus { get; set; }

        public decimal RateAdjusted { get; set; }
        public decimal OpenPriceUnAdjusted { get; set; }
        public decimal ClosePriceUnAdjusted { get; set; }
        public decimal HighestPriceUnAdjusted { get; set; }
        public decimal LowestPriceUnAdjusted { get; set; }
    }
}