using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.CPF
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
	public class DerivativeModel
	{

		public string DerivativeCode { get; set; }

		public string DerivativeName { get; set; }

		public string ComGroupCode { get; set; }

		public string OrganCode { get; set; }

		public string BondCode { get; set; }

		public int Multiplier { get; set; }

		public string TradingStatusCode { get; set; }

		public string TradeTypeCode { get; set; }

		public decimal TickSize { get; set; }

		public string UnitCode { get; set; }

		public decimal ReferencePrice { get; set; }

		public decimal PriceRange { get; set; }

		public int OrderLimit { get; set; }

		public decimal MarginRate { get; set; }

		public DateTime ListingDate { get; set; }

		public DateTime LastTradingDate { get; set; }

		public DateTime PayoutDate { get; set; }

		public string PayoutMethodCode { get; set; }

		public string DailyPayoutPriceMethod { get; set; }

		public string FinalPayoutPriceMethod { get; set; }

		public decimal IndividualPositionLimit { get; set; }

		public decimal CorporatePositionLimit { get; set; }

		public string BondStandard { get; set; }

		public int Status { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime UpdateDate { get; set; }

		public string IsinCode { get; set; }

		public decimal ProfessionalPositionLimit { get; set; }

	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
	public class DerivativeFULLModel
	{

		public string DerivativeCode { get; set; }

		public string DerivativeName { get; set; }

		public string ComGroupCode { get; set; }

		public string OrganCode { get; set; }

		public string BondCode { get; set; }

		public int Multiplier { get; set; }

		public string TradingStatusCode { get; set; }

		public string TradeTypeCode { get; set; }

		public decimal TickSize { get; set; }

		public string UnitCode { get; set; }

		public decimal ReferencePrice { get; set; }

		public decimal PriceRange { get; set; }

		public int OrderLimit { get; set; }

		public decimal MarginRate { get; set; }

		public DateTime ListingDate { get; set; }

		public DateTime LastTradingDate { get; set; }

		public DateTime PayoutDate { get; set; }

		public string PayoutMethodCode { get; set; }

		public string DailyPayoutPriceMethod { get; set; }

		public string FinalPayoutPriceMethod { get; set; }

		public decimal IndividualPositionLimit { get; set; }

		public decimal CorporatePositionLimit { get; set; }

		public string BondStandard { get; set; }

		public string en_DerivativeName { get; set; }

		public string en_DailyPayoutPriceMethod { get; set; }

		public string en_FinalPayoutPriceMethod { get; set; }

		public string en_BondStandard { get; set; }

		public int Status { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime UpdateDate { get; set; }

		public string IsinCode { get; set; }

		public decimal ProfessionalPositionLimit { get; set; }

	}
}
