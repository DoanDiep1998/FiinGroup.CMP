using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models.Chart
{
    public class IndForeignChart
    {
        public DateTime TradingDate { get; set; }
        public decimal FBUY { get; set; }
        public decimal FSELL { get; set; }
        public decimal FNET { get; set; }
    }
}
