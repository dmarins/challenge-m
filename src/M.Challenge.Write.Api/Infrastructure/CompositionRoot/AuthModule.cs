using Autofac;
using M.Challenge.Write.Api.Infrastructure.Auth.Handlers;
using M.Challenge.Write.Domain.Repositories.ApiKey;
using M.Challenge.Write.Infrastructure.Repositories.ApiKey;
using Microsoft.AspNetCore.Authorization;

namespace M.Challenge.Write.Api.Infrastructure.CompositionRoot
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
