using ProtoBuf;

namespace StoxPlus.Core.Models.Master
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class ListOrganizationModel
    {

        public string OrganCode { get; set; }

        //public string IsinCode { get; set; }

        public string Ticker { get; set; }

        public string ComGroupCode { get; set; }

        public string IcbCode { get; set; }

        public string OrganTypeCode { get; set; }

        public string ComTypeCode { get; set; }

        //public string CountryLocationCode { get; set; }

        public string OrganName { get; set; }

        public string OrganShortName { get; set; }

        //public string OrganFriendlyName { get; set; }

        //public int Status { get; set; }

        //public DateTime CreateDate { get; set; }

        //public DateTime UpdateDate { get; set; }

    }
}
