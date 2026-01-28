using ProtoBuf;
using System;

namespace StoxPlus.Core.Models.Master
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class IcbIndustryModel
    {

        public string IcbCode { get; set; }

        public string IcbName { get; set; }

        public string ParentIcbCode { get; set; }

        public string FriendlyName { get; set; }

        public int IcbLevel { get; set; }

        public int IcbOrder { get; set; }

        public string SectorProfile { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string IcbCodePath { get; set; }

        public string IcbNamePath { get; set; }

        public long IndustryID { get; set; }

        public long ParentIndustryID { get; set; }

        public string IcbShortName { get; set; }

    }
}
