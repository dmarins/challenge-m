using M.Challenge.Api.Infrastructure.Auth.Handlers;
using M.Challenge.Api.Infrastructure.Auth.Policies;
using M.Challenge.Api.Infrastructure.Auth.Requirements;
using M.Challenge.Domain.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace M.Challenge.Api
{
    public partial class Startup
    {
        public void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = ApiKeyConstants.DefaultScheme;
                    options.DefaultChallengeScheme = ApiKeyConstants.DefaultScheme;
                })
                .AddApiKeySupport(options => { });
        }

        public void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options
                    .AddPolicy(Policies.Writing,
                        policy => policy
                            .Requirements
                            .Add(new WritingRequirement()));
            });
        }
    }

    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Scheme => ApiKeyConstants.DefaultScheme;
        public string AuthenticationType => ApiKeyConstants.DefaultScheme;
    }

    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddApiKeySupport(this AuthenticationBuilder authenticationBuilder, Action<ApiKeyAuthenticationOptions> options)
        {
            return authenticationBuilder
                .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyConstants.DefaultScheme, options);
        }
    }
}
