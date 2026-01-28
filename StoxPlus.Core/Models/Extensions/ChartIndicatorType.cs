

using ProtoBuf;

namespace StoxPlus.Core.Models.Extensions
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class ChartIndicatorType
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string en_Name { get; set; }

        public string jp_Name { get; set; }

        public int Level { get; set; }

        public string ParentCode { get; set; }

        public string DataTable { get; set; }

        public string ValueField { get; set; }

        public string CodeField { get; set; }

        public string QueryString { get; set; }
    }
}
