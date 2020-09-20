using Autofac;
using M.Challenge.Write.Domain.Logger;
using M.Challenge.Write.Infrastructure.Logger;

namespace M.Challenge.Write.Api.Infrastructure.CompositionRoot
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
