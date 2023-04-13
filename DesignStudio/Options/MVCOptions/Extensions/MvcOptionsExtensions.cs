using System;
using System.ComponentModel;
using DesignStudio.Options.MVCOptions.Converters;
using Microsoft.AspNetCore.Mvc;

namespace DesignStudio.Options.MVCOptions.Extensions
{
    public static class MvcOptionsExtensions
    {
        public static MvcOptions UseDateOnlyTimeOnlyStringConverters(this MvcOptions options)
        {
            TypeDescriptor.AddAttributes(typeof(DateOnly), new TypeConverterAttribute(typeof(DateOnlyTypeConverter)));
            TypeDescriptor.AddAttributes(typeof(TimeOnly), new TypeConverterAttribute(typeof(TimeOnlyTypeConverter)));
            return options;
        }
    }
}
