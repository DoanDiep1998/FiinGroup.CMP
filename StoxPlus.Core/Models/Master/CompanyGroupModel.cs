using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.Master
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class CompanyGroupModel
    {

        public string ComGroupCode { get; set; }

        public string ParentComGroupCode { get; set; }

        public string ComGroupName { get; set; }

        public string FriendlyName { get; set; }

        public int ComGroupType { get; set; }

        public int Priority { get; set; }

        public int CalculateRatio { get; set; }

        public int CalculateReturn { get; set; }

        public int PriorityIcbIndustry { get; set; }

        public int CalculateRatioIcbIndustry { get; set; }

        public int CalculateReturnIcbIndustry { get; set; }

        public int ComGroupOrder { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
