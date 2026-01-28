using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models
{
    public class SignalRMessage<T>
    {
        public string Chanel { get; set; }
        public string Code { set; get; }
        public T Data { get; set; }
    }
}
