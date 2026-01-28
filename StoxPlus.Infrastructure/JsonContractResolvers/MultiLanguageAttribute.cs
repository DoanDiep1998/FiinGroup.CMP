using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class MultiLanguageAttribute : Attribute
    {
        public string Fallback { get; set; }
    }
}
