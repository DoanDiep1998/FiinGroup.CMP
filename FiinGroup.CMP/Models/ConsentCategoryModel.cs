using FiinGroup.Packages.Common.MultiLanguage;

namespace FiinGroup.CMP.PM.Models
{
    public class ConsentCategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        [MultiLanguage]
        public string CategoryName { get; set; }
        public string EnCategoryName { get; set; }

    }
}
