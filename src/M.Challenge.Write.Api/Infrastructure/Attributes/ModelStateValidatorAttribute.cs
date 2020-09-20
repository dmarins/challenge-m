using System;
using System.Diagnostics.CodeAnalysis;

namespace M.Challenge.Write.Api.Infrastructure.Attributes
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ModelStateValidatorAttribute : Attribute { }
}
