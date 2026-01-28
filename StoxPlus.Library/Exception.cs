using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoxPlus.Library
{
    internal class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
    public class ErrorModel
    {
        public ErrorModel(System.Exception exception)
        {
            this.Error = new DF3Exception(exception.GetType().Name, exception.Message);
            // this.Error.Target = $"{exception.TargetSite.ReflectedType.FullName}.{exception.TargetSite.Name}";
            if (exception.InnerException != null)
            {
                this.Error.InnerError = new InnerException(exception.InnerException);
            }
        }

        public DF3Exception Error { get; set; }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver() });
        }
    }

    public class DF3Exception
    {
        public DF3Exception(String code, String message)
        {
            this.Code = code;
            this.Message = message;
        }

        [Required]
        public String Code { get; set; }

        [Required]
        public String Message { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public String Target { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Exception> Details { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InnerException InnerError { get; set; }
    }

    public class InnerException
    {
        public InnerException(System.Exception exception)
        {
            this.Code = exception.GetType().Name;
            if (exception.InnerException != null)
            {
                this.InnerError = new InnerException(exception.InnerException);
            }
        }

        [Required]
        public String Code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InnerException InnerError { get; set; }
    }
}
