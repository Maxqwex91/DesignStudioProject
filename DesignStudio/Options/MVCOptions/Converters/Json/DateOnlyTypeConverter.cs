using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain;
using Domain.Exceptions;

namespace DesignStudio.Options.MVCOptions.Converters
{
    public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString()!;
            string dateStringFormat1 = "dd/MM/yyyy";
            string dateStringFormat2 = "yyyy-MM-dd";
            string dateStringFormat3 = "dd.MM.yyyy";
            if (DateOnly.TryParseExact(dateString,
                    dateStringFormat1,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var dateTimeObj))
            {
                return dateTimeObj;
            }
            else if (DateOnly.TryParseExact(dateString,
                         dateStringFormat2,
                         CultureInfo.InvariantCulture,
                         DateTimeStyles.None,
                         out var dateTimeObj2))
            {
                return dateTimeObj2;
            }
            else if (DateOnly.TryParseExact(dateString,
                         dateStringFormat3,
                         CultureInfo.InvariantCulture,
                         DateTimeStyles.None,
                         out var dateTimeObj3))
            {
                return dateTimeObj3;
            }
            else
            {
                throw new BadRequestException(ErrorMessages.DateOnlyPropertyIsInvalidErrorMessage);
            }
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            var isoDate = value.ToString("dd/MM/yyyy").Replace('.', '/');
            writer.WriteStringValue(isoDate);
        }
    }
}