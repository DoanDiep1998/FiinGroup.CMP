using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StoxPlus.Infrastructure.JsonContractResolvers
{
    public class JsonOptionsWrapper : IConfigureOptions<JsonOptions>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JsonOptionsWrapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Configure(JsonOptions options)
        {
            options.JsonSerializerOptions.Converters.Add(
                new MultiLanguageJsonConverter(_httpContextAccessor)
            );
        }
    }
    public class MultiLanguageJsonConverter : JsonConverter<string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MultiLanguageJsonConverter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.GetString();

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            // ⚠️ nếu value đã được xử lý ở service thì chỉ write thẳng
            writer.WriteStringValue(value);
        }
    }
}
