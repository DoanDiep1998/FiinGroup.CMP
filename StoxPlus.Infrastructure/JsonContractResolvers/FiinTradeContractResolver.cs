using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StoxPlus.Infrastructure.Const;
using StoxPlus.Infrastructure.Enums;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    public class FiinTradeContractResolver : CamelCasePropertyNamesContractResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FiinTradeContractResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = instance => ShouldSerialize(member);
            if (member.GetCustomAttributes<MultiLanguageAttribute>().Any())
            {
                property.ValueProvider = new MultiLanguageValueProvider((PropertyInfo)member, _httpContextAccessor);
            }

            return property;
        }

        #region private

        private bool ShouldSerialize(MemberInfo member)
        {
            return !member.Name.StartsWith("en_") && !member.Name.StartsWith("jp_") && IsPackageAllowed(member) && !IsIgnoreMember(member);
        }

        private bool IsPackageAllowed(MemberInfo member)
        {
            var attrs = member.GetCustomAttributes<RequirePackageViewAttribute>();

            if (!attrs.Any())
            {
                return true;
            }

            var res = true;

            foreach (var attr in attrs)
            {
                res = res && IsPackageAttributeSatified(attr);
            }

            return res;
        }

        private bool IsPackageAttributeSatified(RequirePackageViewAttribute attr)
        {
            var user = _httpContextAccessor.HttpContext.User;

            var packageCond = attr.Operator == LogicOperator.AND ? true : false;
            if (!string.IsNullOrEmpty(attr.Package))
            {
                var package = user.Claims.SingleOrDefault(i => i.Type == "list_package")?.Value;
                packageCond = package == attr.Package;
            }

            var activeCond = attr.Operator == LogicOperator.AND ? true : false;
            if (attr.RequireActive)
            {
                activeCond = user.Identity.IsAuthenticated && DateTime.ParseExact(user.Claims.First(x => x.Type == FiinClaimTypes.EndDate).Value, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= DateTime.Now.Date;
            }

            var registerdCond = attr.Operator == LogicOperator.AND ? true : false;
            if(attr.RequireRegistered)
            {
                registerdCond = user.Identity.IsAuthenticated;
            }

            return attr.Operator == LogicOperator.AND ? packageCond && activeCond && registerdCond : packageCond || activeCond || registerdCond;
        }

        private bool IsIgnoreMember(MemberInfo member)
        {
            var attrs = member.GetCustomAttributes<MemberIgnoreAttribute>();
            if (attrs?.Any() == true) return true;
            return false;
        }

        #endregion
    }
}
