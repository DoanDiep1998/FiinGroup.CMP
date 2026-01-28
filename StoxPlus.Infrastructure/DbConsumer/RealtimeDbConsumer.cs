using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoxPlus.Infrastructure.DbConsumer
{
    public abstract class RealtimeDbConsumer
    {
        protected readonly IConfiguration _config;

        protected ConnectionWrapper _rtConn;

        public RealtimeDbConsumer(IConfiguration config)
        {
            _config = config;
            _rtConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:TIKMarket"]);
        }
    }
}
