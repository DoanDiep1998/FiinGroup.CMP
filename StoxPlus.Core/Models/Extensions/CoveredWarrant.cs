using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models.Extensions
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class CoveredWarrant
    {
        public string CWID { get; set; }
        public string CoveredWarrantCode { get; set; }
        public string CoveredWarrantName { get; set; }
        public string IssuerOrganCode { get; set; }
        public string IssuerTicker { get; set; }
        public string DerivativeTypeCode { get; set; }
        public string OrganCode { get; set; }
        public decimal IssuePrice { get; set; }
        public decimal ExercisePrice { get; set; }
        public decimal ExecutionRateCoveredWarrant { get; set; }
        public decimal ExecutionRateShare { get; set; }
        public DateTime IssueDate { get; set; }
        public string TermStageCode { get; set; }
        public DateTime LastTradingDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public string TradingStatusCode { get; set; }
        public string RightStyleCode { get; set; }
        public string PayoutMethodCode { get; set; }
        public string en_CoveredWarrantName { get; set; }
        public string jp_CoveredWarrantName { get; set; }
        public bool Status { get; set; }
        public string Ticker { get; set; }
        public string StockTicker { get; set; }
        public decimal ShareIssue { get; set; }
        public decimal GuaranteeValue { get; set; }
        public string IsinCode { get; set; }
        public DateTime ListingDate { get; set; }
        public string ComGroupCode { get; set; }
        public string DerivativeTypeName { get; set; }
        public string en_DerivativeTypeName { get; set; }
        public string jp_DerivativeTypeName { get; set; }
    }
}
