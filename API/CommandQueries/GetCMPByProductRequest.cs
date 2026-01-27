using FiinGroup.CMP.API.BLInterfaces;
using FiinGroup.CMP.API.Models;
using FiinGroup.Packages.Mediator;

namespace FiinGroup.CMP.API.CommandQueries
{
    public class GetCMPByProductRequest : IApiRequest<List<PolicyCategoryModel>>
    {
        public string ProductCode { get; set; }

        private class Handler : ApiRequestHandler<GetCMPByProductRequest, List<PolicyCategoryModel>>
        {
            private readonly ICMPService _cmpService;

            public Handler(ILogger<Handler> logger, ICMPService cmpService) : base(logger)
            {
                _cmpService = cmpService;
            }

            public override async Task<List<PolicyCategoryModel>> HandleAsync(GetCMPByProductRequest request, CancellationToken cancellationToken)
            {
                var resultTask = await _cmpService.GetPolicyByProductCodeAsync(request.ProductCode, cancellationToken);

                return resultTask;
            }
        }
    }
}
