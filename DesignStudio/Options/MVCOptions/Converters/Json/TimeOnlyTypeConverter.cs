﻿using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DesignStudio.Options.MVCOptions.Converters
{
    public sealed class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return TimeOnly.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            var isoTime = value.ToString("O");
            writer.WriteStringValue(isoTime);
        }
    }
}
