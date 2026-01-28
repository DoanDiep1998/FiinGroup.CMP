using Microsoft.Extensions.Configuration;

namespace StoxPlus.Infrastructure.DbConsumer
{
    public abstract class WLDbConsumer
    {
        protected readonly IConfiguration _config;

        protected ConnectionWrapper _wLConn;

        public WLDbConsumer(IConfiguration config)
        {
            _config = config;
            _wLConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:WLConnection"]);
        }
    }
}