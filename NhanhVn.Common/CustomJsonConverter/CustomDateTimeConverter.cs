
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NhanhVn.Common.CustomJsonConverter
{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), "yyyy-MM-dd HH:mm:ss", null);
        }
    }
}
