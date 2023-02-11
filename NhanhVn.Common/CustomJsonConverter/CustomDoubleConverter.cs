using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace NhanhVn.Common.CustomJsonConverter
{
    public class CustomDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string stringValue = reader.GetString();
                if (double.TryParse(stringValue, out double result))
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
                return reader.GetDouble();
            }
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }

}
