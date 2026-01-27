using FiinGroup.CMP.API.BLInterfaces;
using FiinGroup.CMP.API.Models;
using StoxPlus.Infrastructure.DbConsumer;
using System.Data;

namespace FiinGroup.CMP.API.BLImplementations
{
    public class CMPService : CMPDbConsumer, ICMPService
    {
        public CMPService(IConfiguration config) : base(config)
        {
        }

        public async Task<List<PolicyCategoryModel>> GetPolicyByProductCodeAsync(string productCode, CancellationToken cancellationToken = default)
        {
            var result = new List<PolicyCategoryModel>();

            const string sql = @"
            SELECT c.CategoryId, c.CategoryCode, c.CategoryName, c.en_CategoryName,
                   p.PolicyId, p.PolicyCode, p.PolicyVersion, p.Content, p.en_Content,
                   pc.IsRequired
            FROM Policy_Category pc
            INNER JOIN Consent_Category c ON pc.CategoryCode = c.CategoryCode
            INNER JOIN Consent_Policy p ON pc.PolicyCode = p.PolicyCode
            WHERE pc.ProductCode = @productCode AND pc.RecordStatus = 1 AND p.RecordStatus = 1 AND c.RecordStatus = 1
            ORDER BY c.CategoryId, p.PolicyId
            ";

            var rows = (await _CMPConn.QueryAsync<PolicyRow>(sql, new { ProductCode = productCode }, CommandType.Text)).ToList();

            var map = new Dictionary<int, PolicyCategoryModel>();

            foreach (var r in rows)
            {
                if (!map.TryGetValue(r.CategoryId, out var pcModel))
                {
                    var category = new ConsentCategoryModel
                    {
                        CategoryId = r.CategoryId,
                        CategoryCode = r.CategoryCode,
                        CategoryName = r.CategoryName,
                        EnCategoryName = r.en_CategoryName
                    };

                    pcModel = new PolicyCategoryModel
                    {
                        PolicyCategory = category,
                        policyModels = new List<ConsentPolicyViewModel>()
                    };

                    map[r.CategoryId] = pcModel;
                }

                var policy = new ConsentPolicyViewModel
                {
                    PolicyId = r.PolicyId,
                    PolicyCode = r.PolicyCode,
                    PolicyVersion = r.PolicyVersion ?? 0,
                    Content = r.Content,
                    EnContent = r.en_Content,
                    IsRequired = r.IsRequired ?? false
                };

                pcModel.policyModels!.Add(policy);
            }

            result.AddRange(map.Values);

            return result;
        }
        private class PolicyRow
        {
            public int CategoryId { get; set; }
            public string CategoryCode { get; set; }
            public string CategoryName { get; set; }
            public string en_CategoryName { get; set; }

            public int PolicyId { get; set; }
            public string PolicyCode { get; set; }
            public int? PolicyVersion { get; set; }
            public string Content { get; set; }
            public string en_Content { get; set; }

            public bool? IsRequired { get; set; }
        }
    }
}
