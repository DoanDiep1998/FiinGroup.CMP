using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.CPF
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
	public class OrganizationFULLModel
	{

		public string OrganCode { get; set; }

		public string IsinCode { get; set; }

		public string ComGroupCode { get; set; }

		public string IcbCode { get; set; }

		public string OrganTypeCode { get; set; }

		public string ComTypeCode { get; set; }

		public string BusTypeBeforeListCode { get; set; }

		public string CountryLocationCode { get; set; }

		public string SecurityOrganCode { get; set; }

		public string MarginStatusCode { get; set; }

		public string ControlStatusCode { get; set; }

		public string Ticker { get; set; }

		public string OrganName { get; set; }

		public string OrganShortName { get; set; }

		public string OrganFriendlyName { get; set; }

		public decimal OutstandingShare { get; set; }

		public decimal FreeFloat { get; set; }

		public decimal FreeFloatRate { get; set; }

		public decimal IssueShare { get; set; }

		public decimal CharterCapital { get; set; }

		public DateTime ListingDate { get; set; }

		public decimal FirstPrice { get; set; }

		public decimal FirstVolumn { get; set; }

		public decimal NumberOfShareHolder { get; set; }

		public DateTime ExDateShareHolder { get; set; }

		public string en_OrganName { get; set; }

		public string en_OrganShortName { get; set; }

		public string en_OrganFriendlyName { get; set; }

		public int Status { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime UpdateDate { get; set; }

		public string AccountingPeriod { get; set; }

	}
}
