using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    public class MultiLanguageContractResolver : CamelCasePropertyNamesContractResolver
    {
        private readonly string _lang;

        public MultiLanguageContractResolver(string lang)
        {
            _lang = lang;            
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = instance => ShouldSerialize(member);
            if (member.GetCustomAttributes<MultiLanguageAttribute>().Any())
            {
                property.ValueProvider = new AssignedMultiLanguageValueProvider((PropertyInfo)member, _lang);
            }

            return property;
        }

        #region private

        private bool ShouldSerialize(MemberInfo member)
        {
            return !member.Name.StartsWith("en_") && !member.Name.StartsWith("jp_");
        }

        #endregion
    }
}
