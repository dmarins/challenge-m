using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;

namespace M.Challenge.Infrastructure.Logger
{
    [ExcludeFromCodeCoverage]
    public class Logger
    {
        public void Info(string message, params object[] propertyValues)
        {
            Log.Information(message, propertyValues);
        }

        public void Error(string message, Exception exception, params object[] propertyValues)
        {
            Log.Error(exception, message, propertyValues);
        }

        public void Warning(string message, Exception exception = null, params object[] propertyValues)
        {
            Log.Warning(exception, message, propertyValues);
        }
    }
}
