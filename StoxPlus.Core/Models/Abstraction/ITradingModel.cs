using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models.Abstraction
{
    public interface ITradingModel
    {
        DateTime TradingDate { get; set; }
    }
}
