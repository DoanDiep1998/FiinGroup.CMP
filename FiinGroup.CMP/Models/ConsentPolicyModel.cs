
using FiinGroup.Packages.Common.MultiLanguage;

namespace FiinGroup.CMP.PM.Models
{
    public class ConsentPolicyModel
    {
        public int PolicyId { get; set; }
        public string PolicyCode { get; set; }
        public int PolicyVersion { get; set; }
        [MultiLanguage]
        public string Content { get; set; } = default!;
        public string en_Content { get; set; } = default!;

    }
    public class ConsentPolicyViewModel
    {
        public int PolicyId { get; set; }
        public string PolicyCode { get; set; }
        public bool IsRequired { get; set; }
        public int PolicyVersion { get; set; }
        [MultiLanguage]
        public string Content { get; set; } = default!;
        public string en_Content { get; set; } = default!;

    }
}
