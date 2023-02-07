﻿
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NhanhVn.Services
{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), "yyyy-MM-dd", null);
        }
    }
}
