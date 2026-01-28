using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.Models
{
    public interface IHasIcbCode
    {
        string IcbCode { get; set; }
    }
}
