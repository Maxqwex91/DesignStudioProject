using System;
using System.Globalization;
using Domain;
using Domain.Exceptions;

namespace DesignStudio.Options.MVCOptions.Converters
{
    public class DateOnlyTypeConverter : StringTypeConverterBase<DateOnly>
    {
        private const string _dateFormat1 = "dd/MM/yyyy";
        private const string _dateFormat2 = "yyyy-MM-dd";
        private const string _dateFormat3 = "dd.MM.yyyy";

        protected override DateOnly Parse(string s)
        {
            if (DateOnly.TryParseExact(s,
                    _dateFormat1,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var dateTimeObj))
            {
                return dateTimeObj;
            }

            if (DateOnly.TryParseExact(s,
                    _dateFormat2,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var dateTimeObj2))
            {
                return dateTimeObj2;
            }

            if (DateOnly.TryParseExact(s,
                    _dateFormat3,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var dateTimeObj3))
            {
                return dateTimeObj3;
            }

            throw new BadRequestException(ErrorMessages.DateOnlyPropertyIsInvalidErrorMessage);
        }

        protected override string ToIsoString(DateOnly source)
        {
            return source.ToString("dd/MM/yyyy").Replace('.', '/');
        }
    }
}