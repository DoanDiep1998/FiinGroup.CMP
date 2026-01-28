using Microsoft.Extensions.Configuration;

namespace StoxPlus.Infrastructure.DbConsumer
{
    public abstract class CMPDbConsumer
    {
        protected readonly IConfiguration _config;

        protected ConnectionWrapper _CMPConn;

        public CMPDbConsumer(IConfiguration config)
        {
            _config = config;
            _CMPConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:FiinCMP"]);

        }
    }
}
