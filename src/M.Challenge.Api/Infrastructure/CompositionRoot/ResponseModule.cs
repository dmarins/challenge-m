using Autofac;
using M.Challenge.Api.Infrastructure.Response;

namespace M.Challenge.Api.Infrastructure.CompositionRoot
{
    public class ResponseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ResponseFactory>()
                .As<IResponseFactory>()
                .SingleInstance();
        }
    }
}
