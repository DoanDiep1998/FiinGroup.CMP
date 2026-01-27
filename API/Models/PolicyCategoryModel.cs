namespace FiinGroup.CMP.API.Models
{
    public class PolicyCategoryModel
    {
        public ConsentCategoryModel? PolicyCategory { get; set; }
        public List<ConsentPolicyViewModel>? policyModels { get; set; }

    }
}
