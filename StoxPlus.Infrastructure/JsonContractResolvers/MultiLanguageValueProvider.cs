using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    public class MultiLanguageValueProvider : IValueProvider
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MultiLanguageValueProvider(PropertyInfo propertyInfo
            , IHttpContextAccessor httpContextAccessor)
        {
            _propertyInfo = propertyInfo;
            _httpContextAccessor = httpContextAccessor;
        }

        public object GetValue(object target)
        {
            var context = _httpContextAccessor.HttpContext;
            var lang = "vi";
            if(context.Request.Query.ContainsKey("language"))
            {
                lang = context.Request.Query["language"];
            }

            var enPropName = _propertyInfo.Name;
            PropertyInfo enProp = _propertyInfo;

            switch(lang)
            {
                case "en":
                    enPropName = "en_" + _propertyInfo.Name;
                    enProp = _propertyInfo.DeclaringType.GetProperty(enPropName);
                    break;
                case "ja":
                    enPropName = "jp_" + _propertyInfo.Name;
                    enProp = _propertyInfo.DeclaringType.GetProperty(enPropName);
                    break;
                default:
                    break;
            }
            object res = null;
            if (enProp != null)
            {
                res = enProp.GetValue(target);
                if (string.IsNullOrEmpty(res as string))
                {
                    var attr = _propertyInfo.GetCustomAttributes<MultiLanguageAttribute>().FirstOrDefault();
                    if (attr != null && !string.IsNullOrEmpty(attr.Fallback))
                    {
                        var fallbackProp = _propertyInfo.DeclaringType.GetProperty(attr.Fallback);
                        if(fallbackProp != null)
                        {
                            res = fallbackProp.GetValue(target);
                        }
                    }

                }
            }
            return res;
        }

        public void SetValue(object target, object value)
        {
            _propertyInfo.SetValue(target, value);
        }
    }
}
