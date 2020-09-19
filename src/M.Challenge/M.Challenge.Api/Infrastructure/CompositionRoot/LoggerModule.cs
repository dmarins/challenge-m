using Autofac;
using M.Challenge.Domain.Logger;
using M.Challenge.Infrastructure.Logger;

namespace M.Challenge.Api.Infrastructure.CompositionRoot
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Logger>()
                .As<ILogger>()
                .SingleInstance();
        }
    }
}
