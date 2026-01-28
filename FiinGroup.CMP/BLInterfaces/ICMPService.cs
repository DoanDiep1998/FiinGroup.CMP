using FiinGroup.CMP.PM.Models;
using FiinGroup.CMP.PM.Models.ViewModels;

namespace FiinGroup.CMP.PM.BLInterfaces
{
    public interface ICMPService
    {
        Task<List<PolicyCategoryModel>> GetPolicyByProductCodeAsync(string productCode, CancellationToken cancellationToken = default);
        Task<IpLocationResult?> GetLocationByIpAsync(string ip);
        Task<bool> InsertConsentSubmissionAsync(SubmitConsentRequest request, CancellationToken cancellationToken = default);
    }
}
