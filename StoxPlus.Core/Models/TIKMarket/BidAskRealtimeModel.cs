using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.TIKMarket
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public partial class BidAskRealtimeModel
    {

        public long BidAskId { get; set; }

        public string OrganCode { get; set; }

        public string Ticker { get; set; }

        public string ComGroupCode { get; set; }

        public DateTime TradingDate { get; set; }

        public decimal Best1Bid { get; set; }

        public decimal Best1BidVolume { get; set; }

        public decimal Best2Bid { get; set; }

        public decimal Best2BidVolume { get; set; }

        public decimal Best3Bid { get; set; }

        public decimal Best3BidVolume { get; set; }

        public decimal Best1Offer { get; set; }

        public decimal Best1OfferVolume { get; set; }

        public decimal Best2Offer { get; set; }

        public decimal Best2OfferVolume { get; set; }

        public decimal Best3Offer { get; set; }

        public decimal Best3OfferVolume { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public decimal Best4Bid { get; set; }

        public decimal Best4BidVolume { get; set; }

        public decimal Best5Bid { get; set; }

        public decimal Best5BidVolume { get; set; }

        public decimal Best6Bid { get; set; }

        public decimal Best6BidVolume { get; set; }

        public decimal Best4Offer { get; set; }

        public decimal Best4OfferVolume { get; set; }

        public decimal Best5Offer { get; set; }

        public decimal Best5OfferVolume { get; set; }

        public decimal Best6Offer { get; set; }

        public decimal Best6OfferVolume { get; set; }

        public decimal Best7Bid { get; set; }

        public decimal Best7BidVolume { get; set; }

        public decimal Best8Bid { get; set; }

        public decimal Best8BidVolume { get; set; }

        public decimal Best9Bid { get; set; }

        public decimal Best9BidVolume { get; set; }

        public decimal Best7Offer { get; set; }

        public decimal Best7OfferVolume { get; set; }

        public decimal Best8Offer { get; set; }

        public decimal Best8OfferVolume { get; set; }

        public decimal Best9Offer { get; set; }

        public decimal Best9OfferVolume { get; set; }

        public decimal Best10Bid { get; set; }

        public decimal Best10BidVolume { get; set; }

        public decimal Best11Bid { get; set; }

        public decimal Best11BidVolume { get; set; }

        public decimal Best12Bid { get; set; }

        public decimal Best12BidVolume { get; set; }

        public decimal Best10Offer { get; set; }

        public decimal Best10OfferVolume { get; set; }

        public decimal Best11Offer { get; set; }

        public decimal Best11OfferVolume { get; set; }

        public decimal Best12Offer { get; set; }

        public decimal Best12OfferVolume { get; set; }

        public decimal Best13Bid { get; set; }

        public decimal Best13BidVolume { get; set; }

        public decimal Best14Bid { get; set; }

        public decimal Best14BidVolume { get; set; }

        public decimal Best15Bid { get; set; }

        public decimal Best15BidVolume { get; set; }

        public decimal Best13Offer { get; set; }

        public decimal Best13OfferVolume { get; set; }

        public decimal Best14Offer { get; set; }

        public decimal Best14OfferVolume { get; set; }

        public decimal Best15Offer { get; set; }

        public decimal Best15OfferVolume { get; set; }

        public string StockType { set; get; }

    }
}
