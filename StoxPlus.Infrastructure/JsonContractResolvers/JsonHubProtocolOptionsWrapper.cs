using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    public class JsonHubProtocolOptionsWrapper : IConfigureOptions<JsonHubProtocolOptions>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JsonHubProtocolOptionsWrapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Configure(JsonHubProtocolOptions options)
        {
            //options.PayloadSerializerSettings.ContractResolver = new FiinTradeContractResolver(_httpContextAccessor);
        }
    }
}
