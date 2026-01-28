using FiinGroup.Packages.Common.MultiLanguage;

namespace FiinGroup.CMP.PM.Models.ViewModels
{
    public class PolicyRow
    {
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string ParentCategoryCode { get; set; }
        [MultiLanguage]
        public string CategoryName { get; set; }
        public string en_CategoryName { get; set; }

        public int PolicyId { get; set; }
        public string PolicyCode { get; set; }
        public int? PolicyVersion { get; set; }
        [MultiLanguage]
        public string Content { get; set; }
        public string en_Content { get; set; }

        public bool? IsRequired { get; set; }
    }
}
