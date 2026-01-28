using FiinGroup.Packages.Common.MultiLanguage;

namespace FiinGroup.CMP.PM.Models
{
    public class ConsentCategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string ParentCategoryCode { get; set; }
        [MultiLanguage]
        public string CategoryName { get; set; }
        public string en_CategoryName { get; set; }
        public List<ConsentCategoryModel> Children { get; set; } = new();

    }
}
