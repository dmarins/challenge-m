using M.Challenge.Api.Infrastructure.Auth.Requirements;
using M.Challenge.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace M.Challenge.Api.Infrastructure.Auth.Handlers
{
    [ExcludeFromCodeCoverage]
    public class WritingAuthorizationHandler : AuthorizationHandler<WritingRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WritingRequirement requirement)
        {
            if (context.User.IsInRole(Role.Writing))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
