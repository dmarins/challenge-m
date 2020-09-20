using System;
using System.Diagnostics.CodeAnalysis;

namespace M.Challenge.Api.Infrastructure.Attributes
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ModelStateValidatorAttribute : Attribute { }
}
