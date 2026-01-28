namespace FiinGroup.CMP.PM.Models
{
    public class PolicyCategoryModel
    {
        public ConsentCategoryModel? PolicyCategory { get; set; }
        public List<ConsentPolicyViewModel>? policyModels { get; set; }

    }
}
