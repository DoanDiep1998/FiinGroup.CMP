using StoxPlus.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    /// <summary>
    /// for stack (multi attributes for a property), default operator is OR
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class RequirePackageViewAttribute : Attribute
    {
        public string Package { get; set; }

        public bool RequireActive { get; set; }

        public bool RequireRegistered { get; set; }

        /// <summary>
        /// how to combine conditions
        /// default AND
        /// </summary>
        public LogicOperator Operator { get; set; } = LogicOperator.AND;

        public RequirePackageViewAttribute()
        {

        }

        public RequirePackageViewAttribute(string package)
        {
            Package = package;
        }
    }
}
