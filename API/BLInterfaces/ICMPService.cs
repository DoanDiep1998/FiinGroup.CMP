using FiinGroup.CMP.API.Models;

namespace FiinGroup.CMP.API.BLInterfaces
{
    public interface ICMPService
    {
        Task<List<PolicyCategoryModel>> GetPolicyByProductCodeAsync(string productCode, CancellationToken cancellationToken = default);
    }
}
