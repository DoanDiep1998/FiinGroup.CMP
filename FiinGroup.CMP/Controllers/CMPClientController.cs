using FiinGroup.CMP.PM.BLInterfaces;
using FiinGroup.CMP.PM.Models;
using FiinGroup.CMP.PM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using StoxPlus.Infrastructure.Utils;
using System.Text.Json;

namespace FiinGroup.CMP.Controllers
{
    public class CMPClientController : Controller
    {
        private readonly ICMPService _cMPService;
        private readonly IConfiguration _config;
        public CMPClientController(ICMPService cMPService, IConfiguration config)
        {
            _cMPService = cMPService;
            _config = config;
        }
        public IActionResult Index(string productCode)
        {
            return View();
        }

        public async Task<IActionResult> FrameContent(string productCode, string email)
        {

            ViewData["ProductCode"] = productCode ?? string.Empty;
            ViewData["Email"] = email ?? string.Empty;
            return View();
        }
        public async Task<IActionResult> GetPolicyContent(string productCode)
        {
            List<PolicyCategoryModel> rs = await _cMPService.GetTreePolicyByProductCodeAsync(productCode);

            ViewData["ProductCode"] = productCode ?? string.Empty;
            return Json(rs);
        }
        [HttpPost]
        public async Task<IActionResult> SaveConsent([FromBody] SaveConsentRequest request)
        {
            if (string.IsNullOrEmpty(request.ProductCode))
                return BadRequest("ProductCode is required");


            // 2. Audit info
            string ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault()?.Split(',').FirstOrDefault()
                ?? HttpContext.Connection.RemoteIpAddress?.ToString()
                ?? "unknown";

            string userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
            DateTime consentTime = DateTime.UtcNow;

            // 3. Validate policy server-side
            var validPolicies =
                await _cMPService.GetPolicyByProductCodeAsync(request.ProductCode);

            var validPolicyCodes =
                validPolicies.Select(p => p.PolicyCode)
                    .ToHashSet();

            var acceptedConsents = request.Consents
                .Where(c => validPolicyCodes.Contains(c.PolicyCode))
                .Select(c => new SubmitPolicyItem
                {
                    PolicyCode = c.PolicyCode,
                    IsAccepted = c.Accepted
                })
                .ToList();

            // 4. Location
            //IpLocationResult? location = await _cMPService.GetLocationByIpAsync(ip);

            //string country = location?.Country;
            //string region = location?.RegionName;
            //string city = location?.City;

            // 5. Build insert request
            var insertRequest = new SubmitConsentRequest
            {
                IdentityKey = Guid.NewGuid().ToString("N"),
                ProductCode = request.ProductCode,
                Email = request.Email,
                UserInfo = request.UserInfo,
                ClientInfo = JsonSerializer.Serialize(new
                {
                    Ip = ip,
                    UserAgent = userAgent,
                    //Country = country,
                    //Region = region,
                    //City = city,
                    ConsentTime = consentTime
                }),
                Policies = acceptedConsents
            };
            // 6. Insert
            await _cMPService.InsertConsentSubmissionAsync(insertRequest);

            return Ok(new
            {
                success = true,
                timestamp = consentTime
            });
        }
        [HttpPost]
        public async Task<IActionResult> InsertDataLink([FromBody] List<DataLinkViewModel> request)
        {
            List<DataLinkModel> dataLinkModels = new List<DataLinkModel>();
            foreach (var item in request)
            {
                if (string.IsNullOrWhiteSpace(item.Email))
                    continue;
                string serverSecret = _config["CMP:ServerSecret"]!;
                string encryptUserInfo;
                try
                {
                    encryptUserInfo = EncryptDecryptUserInfoUtils.EncryptUserInfo(
                        item.UserInfo,
                        item.Email,
                        serverSecret);
                }
                catch
                {
                    return BadRequest("Decrypt failed");
                }
                DataLinkModel dataLinkModel = new DataLinkModel
                {
                    ProductCode = item.ProductCode,
                    UserInfo = item.UserInfo,
                    Email = item.Email,
                    EncryptData = encryptUserInfo
                };
            }

            var rs = await _cMPService.InsertDataLink(dataLinkModels);
            if (!rs)
            {
                return BadRequest("Insert failed");
            }
            return Ok(new { success = true });
        }
    }
}
