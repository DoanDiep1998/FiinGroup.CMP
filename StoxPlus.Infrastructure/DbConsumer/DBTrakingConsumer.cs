using Microsoft.Extensions.Configuration;

namespace StoxPlus.Infrastructure.DbConsumer
{
    public abstract class DBTrakingConsumer
    {
        protected readonly IConfiguration _config;

        protected ConnectionWrapper _trackingConn;

        public DBTrakingConsumer(IConfiguration config)
        {
            _config = config;
            _trackingConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:TradingItegration"]);
        }
    }
}
