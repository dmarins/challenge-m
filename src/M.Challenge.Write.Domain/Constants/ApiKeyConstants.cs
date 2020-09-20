using System.Diagnostics.CodeAnalysis;

namespace M.Challenge.Write.Domain.Constants
{
    [ExcludeFromCodeCoverage]
    public static class ApiKeyConstants
    {
        public const string HeaderName = "X-Api-Key";
        public const string DefaultScheme = "API Key";
    }
}
