using DesignStudio.Options.MVCOptions.Converters;
using Microsoft.AspNetCore.Mvc;

namespace DesignStudio.Options.MVCOptions.Extensions
{
    public static class JsonOptionsExtensions
    {
        public static JsonOptions UseDateOnlyTimeOnlyStringConverters(this JsonOptions options)
        {
            options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
            return options;
        }
    }
}
