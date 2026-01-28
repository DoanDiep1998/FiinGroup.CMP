using Newtonsoft.Json;
using System;

namespace StoxPlus.Core.Models.ApiResult
{
    public class OhlcRealtimeApiRes
    {
        [JsonProperty("organizationId")]
        public long OrganizationId { get; set; }

        [JsonProperty("organCode")]
        public string OrganCode { get; set; }

        [JsonProperty("comGroupCode")]
        public string ComGroupCode { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("tradingDate")]
        public DateTime TradingDate { get; set; }

        [JsonProperty("ceilingPrice")]
        public decimal CeilingPrice { get; set; }

        [JsonProperty("floorPrice")]
        public decimal FloorPrice { get; set; }

        [JsonProperty("referencePrice")]
        public decimal ReferencePrice { get; set; }

        [JsonProperty("referenceDate")]
        public DateTime ReferenceDate { get; set; }

        [JsonProperty("openPrice")]
        public decimal OpenPrice { get; set; }

        [JsonProperty("closePrice")]
        public decimal ClosePrice { get; set; }

        [JsonProperty("matchPrice")]
        public decimal MatchPrice { get; set; }

        [JsonProperty("priceChange")]
        public decimal PriceChange { get; set; }

        [JsonProperty("percentPriceChange")]
        public double PercentPriceChange { get; set; }

        [JsonProperty("highestPrice")]
        public decimal HighestPrice { get; set; }

        [JsonProperty("lowestPrice")]
        public decimal LowestPrice { get; set; }

        [JsonProperty("averagePrice")]
        public decimal AveragePrice { get; set; }

        [JsonProperty("matchVolume")]
        public decimal MatchVolume { get; set; }

        [JsonProperty("matchValue")]
        public decimal MatchValue { get; set; }

        [JsonProperty("totalMatchVolume")]
        public decimal TotalMatchVolume { get; set; }

        [JsonProperty("totalMatchValue")]
        public decimal TotalMatchValue { get; set; }

        [JsonProperty("totalDealVolume")]
        public decimal TotalDealVolume { get; set; }

        [JsonProperty("totalDealValue")]
        public decimal TotalDealValue { get; set; }

        [JsonProperty("totalVolume")]
        public decimal TotalVolume { get; set; }

        [JsonProperty("totalValue")]
        public decimal TotalValue { get; set; }

        [JsonProperty("foreignBuyValueTotal")]
        public decimal ForeignBuyValueTotal { get; set; }

        [JsonProperty("foreignBuyVolumeTotal")]
        public decimal ForeignBuyVolumeTotal { get; set; }

        [JsonProperty("foreignSellValueTotal")]
        public decimal ForeignSellValueTotal { get; set; }

        [JsonProperty("foreignSellVolumeTotal")]
        public decimal ForeignSellVolumeTotal { get; set; }

        [JsonProperty("foreignTotalRoom")]
        public decimal ForeignTotalRoom { get; set; }

        [JsonProperty("foreignCurrentRoom")]
        public decimal ForeignCurrentRoom { get; set; }

        [JsonProperty("dealVolume")]
        public decimal DealVolume { get; set; }

        [JsonProperty("dealValue")]
        public decimal DealValue { get; set; }

        [JsonProperty("dealPrice")]
        public decimal DealPrice { get; set; }

        [JsonProperty("matchType")]
        public int MatchType { get; set; }

        [JsonProperty("totalBuyTradeVolume")]
        public decimal TotalBuyTradeVolume { get; set; }

        [JsonProperty("totalSellTradeVolume")]
        public decimal TotalSellTradeVolume { get; set; }

        //[JsonProperty("marketStatus")]
        //public object MarketStatus { get; set; }

        [JsonProperty("rateAdjusted")]
        public decimal RateAdjusted { get; set; }

        [JsonProperty("openPriceUnAdjusted")]
        public decimal OpenPriceUnAdjusted { get; set; }

        [JsonProperty("closePriceUnAdjusted")]
        public decimal ClosePriceUnAdjusted { get; set; }

        [JsonProperty("highestPriceUnAdjusted")]
        public decimal HighestPriceUnAdjusted { get; set; }

        [JsonProperty("lowestPriceUnAdjusted")]
        public decimal LowestPriceUnAdjusted { get; set; }
    }
}