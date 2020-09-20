using System.Diagnostics.CodeAnalysis;

namespace M.Challenge.Domain.Constants
{
    [ExcludeFromCodeCoverage]
    public static class ApiKeyConstants
    {
        public static string HeaderName => "X-Api-Key";
        public static string DefaultScheme => "API Key";
    }
}
