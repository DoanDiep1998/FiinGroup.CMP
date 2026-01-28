using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StoxPlus.Infrastructure.DbConsumer
{
    public abstract class EndOfDayDbConsumer
    {
        protected readonly IConfiguration _config;

        protected ConnectionWrapper _eodConn;

        public EndOfDayDbConsumer(IConfiguration config)
        {
            _config = config;
            _eodConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:SDv2"]);
        }
    }
}
