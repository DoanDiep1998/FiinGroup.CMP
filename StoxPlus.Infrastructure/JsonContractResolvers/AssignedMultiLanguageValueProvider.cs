using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    class AssignedMultiLanguageValueProvider : IValueProvider
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly string _lang;

        public AssignedMultiLanguageValueProvider(PropertyInfo propertyInfo
            , string lang)
        {
            _propertyInfo = propertyInfo;
            _lang = lang;
        }

        public object GetValue(object target)
        {
            var enPropName = _propertyInfo.Name;
            PropertyInfo enProp = _propertyInfo;

            switch (_lang)
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
                        if (fallbackProp != null)
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
