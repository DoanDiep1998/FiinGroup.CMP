using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models.Chart
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class IndBusdChart
    {
        public DateTime TradingDate { get; set; }
        public decimal BU { get; set; }
        public decimal SD { get; set; }
    }
}
