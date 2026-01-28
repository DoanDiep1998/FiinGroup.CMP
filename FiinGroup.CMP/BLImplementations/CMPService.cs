using Dapper;
using FiinGroup.CMP.PM.BLInterfaces;
using FiinGroup.CMP.PM.Models;
using FiinGroup.CMP.PM.Models.ViewModels;
using FiinGroup.Packages.Common.MultiLanguage;
using StoxPlus.Infrastructure.DbConsumer;
using System.Data;
using System.Text.Json;

namespace FiinGroup.CMP.PM.BLImplementations
{
    public class CMPService : CMPDbConsumer, ICMPService
    {
        public CMPService(IConfiguration config) : base(config)
        {
        }
        private static DataTable CreatePolicyTable(IEnumerable<SubmitPolicyItem> policies)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PolicyCode", typeof(string));
            table.Columns.Add("IsAccepted", typeof(bool));

            foreach (var p in policies)
            {
                table.Rows.Add(p.PolicyCode, p.IsAccepted);
            }

            return table;
        }

        public async Task<bool> InsertConsentSubmissionAsync(SubmitConsentRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var policyTable = CreatePolicyTable(request.Policies);

                var parameters = new DynamicParameters();
                parameters.Add("@IdentityKey", request.IdentityKey);
                parameters.Add("@UserInfo", request.UserInfo);
                parameters.Add("@ClientInfo", request.ClientInfo);
                parameters.Add("@ProductCode", request.ProductCode);
                parameters.Add("@Email", request.Email);
                parameters.Add("@CreateBy", request.CreateBy);
                parameters.Add("@Policies", policyTable.AsTableValuedParameter("dbo.PolicyConsentType"));

                await _CMPConn.ExecuteAsync(
                    "dbo.sp_InsertConsentSubmission",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IpLocationResult?> GetLocationByIpAsync(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip) || ip == "unknown")
                return null;

            using HttpClient client = new HttpClient();
            string url = $"http://ip-api.com/json/{ip}?fields=status,country,countryCode,regionName,city,query";

            HttpResponseMessage response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            string json = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(json);

            if (doc.RootElement.GetProperty("status").GetString() != "success")
                return null;

            return JsonSerializer.Deserialize<IpLocationResult>(json);
        }
        public async Task<List<ConsentPolicyModel>> GetPolicyByProductCodeAsync(
string productCode,
CancellationToken cancellationToken = default)
        {
            const string policySql = @"
SELECT pc.CategoryCode,
       p.PolicyId,
       p.PolicyCode,
       p.PolicyVersion,
       p.Content,
       p.en_Content,
       pc.IsRequired
FROM FGCMP_DR_Policy_Category_Product pc
INNER JOIN FGCMP_DM_Policy p ON pc.PolicyCode = p.PolicyCode
WHERE pc.ProductCode = @ProductCode
  AND pc.RecordStatus = 1
  AND p.RecordStatus = 1;
";

            var policies = (await _CMPConn.QueryAsync<ConsentPolicyModel>(
                policySql, new { ProductCode = productCode })).ToList();
            return policies;
        }
        public async Task<List<PolicyCategoryModel>> GetTreePolicyByProductCodeAsync(string productCode, CancellationToken cancellationToken = default)
        {
            if (productCode == null)
            {
                return new List<PolicyCategoryModel>();
            }
            const string policySql = @"
                            SELECT pc.CategoryCode,
                                   p.PolicyId,
                                   p.PolicyCode,
                                   p.PolicyVersion,
                                   p.Content,
                                   p.en_Content,
                                   pc.IsRequired
                            FROM FGCMP_DR_Policy_Category_Product pc
                            INNER JOIN FGCMP_DM_Policy p ON pc.PolicyCode = p.PolicyCode
                            WHERE pc.ProductCode = @ProductCode
                              AND pc.RecordStatus = 1
                              AND p.RecordStatus = 1;
                            ";
            const string categorySql = @"
                            SELECT CategoryId,
                                   CategoryCode,
                                   ParentCategoryCode,
                                   CategoryName,
                                   en_CategoryName
                            FROM FGCMP_DM_Category
                            WHERE RecordStatus = 1;
                            ";
            // 1️⃣ Load all categories
            var categories = (await _CMPConn.QueryAsync<ConsentCategoryModel>(
                categorySql)).ToList();

            // 2️⃣ Load policies by product
            var policies = (await _CMPConn.QueryAsync<PolicyRow>(
                policySql, new { ProductCode = productCode })).ToList();
            if (policies.Count == 0)
            {
                return new List<PolicyCategoryModel>();
            }
            // 3️⃣ Map CategoryCode -> PolicyCategoryModel
            var categoryMap = categories.ToDictionary(
                 c => c.CategoryCode,
                 c => new PolicyCategoryModel
                 {
                     PolicyCategory = new ConsentCategoryModel
                     {
                         CategoryId = c.CategoryId,
                         CategoryCode = c.CategoryCode,
                         ParentCategoryCode = c.ParentCategoryCode,
                         CategoryName = c.CategoryName,
                         en_CategoryName = c.en_CategoryName,
                         Children = new List<ConsentCategoryModel>() // ⭐ QUAN TRỌNG
                     },
                     PolicyModels = new List<ConsentPolicyViewModel>()
                 });
            // 4️⃣ Attach policy to category
            foreach (var p in policies)
            {
                if (!categoryMap.TryGetValue(p.CategoryCode, out var categoryNode))
                    continue;

                categoryNode.PolicyModels.Add(new ConsentPolicyViewModel
                {
                    PolicyId = p.PolicyId,
                    PolicyCode = p.PolicyCode,
                    PolicyVersion = p.PolicyVersion ?? 0,
                    Content = p.Content,
                    en_Content = p.en_Content,
                    IsRequired = p.IsRequired ?? false
                });
            }

            // 5️⃣ Build tree
            var roots = new List<PolicyCategoryModel>();

            foreach (var node in categoryMap.Values)
            {
                var parentCode = node.PolicyCategory.ParentCategoryCode;

                if (!string.IsNullOrEmpty(parentCode)
                    && categoryMap.TryGetValue(parentCode, out var parent))
                {
                    // ✅ add CẢ NODE
                    parent.Children.Add(node);
                }
                else
                {
                    roots.Add(node);
                }
            }

            return roots;
        }

        private class PolicyRow
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
}
