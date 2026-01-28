using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StoxPlus.Infrastructure.DbConsumer
{
    public abstract class BothTypesOfDbConsumer
    {
        protected readonly IConfiguration _config;

        protected ConnectionWrapper _eodConn;
        protected ConnectionWrapper _rtConn;
        protected ConnectionWrapper _fiinConn;
        protected ConnectionWrapper _fiinProduct;

        public BothTypesOfDbConsumer(IConfiguration config)
        {
            _config = config;
            _eodConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:SDv2"]);
            _rtConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:TIKMarket"]);
            _fiinConn = new ConnectionWrapper(config["AppSettings:ConnectionStrings:FiinTrade"]);
            _fiinProduct = new ConnectionWrapper(config["AppSettings:ConnectionStrings:FiinProductManager"]);
        }
    }
}
