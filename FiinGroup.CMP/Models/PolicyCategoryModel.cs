namespace FiinGroup.CMP.PM.Models
{
    public class PolicyCategoryModel
    {
        public ConsentCategoryModel? PolicyCategory { get; set; }
        public List<ConsentPolicyViewModel>? PolicyModels { get; set; } = new List<ConsentPolicyViewModel>();
        public List<PolicyCategoryModel> Children { get; set; } = new();
    }
}
