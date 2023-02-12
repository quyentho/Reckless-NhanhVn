using System.Text.Json.Serialization;
using System.Text.Json;

namespace NhanhVn.Common.CustomJsonConverter
{
    public class IntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string stringValue = reader.GetString();
                if (int.TryParse(stringValue, out int result))
                {
                    return result;
                }
                else
                {
                    throw new JsonException($"Invalid int value: {stringValue}");
                }
            }
            else
            {
                return reader.GetInt32();
            }
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }

}
