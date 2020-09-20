using Autofac;
using M.Challenge.Api.Infrastructure.Auth.Handlers;
using M.Challenge.Domain.Repositories.ApiKey;
using M.Challenge.Infrastructure.Repositories.ApiKey;
using Microsoft.AspNetCore.Authorization;

namespace M.Challenge.Api.Infrastructure.CompositionRoot
{
    public class AuthModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<InMemoryApiKeyRepository>()
                .As<IInMemoryApiKeyRepository>();

            builder
                .RegisterType<WritingAuthorizationHandler>()
                .As<IAuthorizationHandler>();
        }
    }
}
