using Dapper;
using FiinGroup.CMP.PM.BLInterfaces;
using FiinGroup.CMP.PM.Models;
using FiinGroup.CMP.PM.Models.ViewModels;
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
                parameters.Add("@UserInfor", request.UserInfo);
                parameters.Add("@UserInfoClient", request.UserInfoClient);
                parameters.Add("@ProductCode", request.ProductCode);
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
