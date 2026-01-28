using Microsoft.Extensions.Configuration;

namespace StoxPlus.Infrastructure.DbConsumer
{
    public class FiinAppDb
    {
        protected readonly IConfiguration _config;

        protected ConnectionWrapper _fiinConn;

        public FiinAppDb(IConfiguration config)
        {
            _config = config;
            _fiinConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:FiinTrade"]);
        }
    }
}