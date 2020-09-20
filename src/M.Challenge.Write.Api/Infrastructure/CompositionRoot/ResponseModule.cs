using Autofac;
using M.Challenge.Write.Api.Infrastructure.Response;

namespace M.Challenge.Write.Api.Infrastructure.CompositionRoot
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
