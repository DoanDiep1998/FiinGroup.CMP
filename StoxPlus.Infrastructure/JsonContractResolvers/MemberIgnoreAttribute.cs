using System;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MemberIgnoreAttribute : Attribute
    {

    }
}
