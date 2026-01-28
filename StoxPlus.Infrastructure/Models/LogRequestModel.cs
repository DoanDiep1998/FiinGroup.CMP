using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Models
{
    public  class LogRequestModel
    {
        public long UserId { get; set; }
        public Guid? UserEmbedId { get; set; }
        public string Origin { get; set; }
        public string Service { get; set; }
        public string Query { get; set; }
        public string Params { get; set; }
        public string UserAgent { get; set; }
        public bool? IsBlock { get; set; }
        public string RemoteIP { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class LogCCUModel
    {
        public long UserId { get; set; }
        public string ConnectionId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsOnConnect { get; set; }  // true: connect, false: disconnect

    }
}
