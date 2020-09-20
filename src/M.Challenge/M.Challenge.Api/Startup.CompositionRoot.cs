using Autofac;
using Autofac.Extensions.DependencyInjection;
using M.Challenge.Api.Infrastructure.CompositionRoot;
using Microsoft.Extensions.DependencyInjection;

namespace M.Challenge.Api
{
    public partial class Startup
    {
        public AutofacServiceProvider RegisterDependencies(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(services);
            containerBuilder.Register(ctx => Configuration);

            containerBuilder.RegisterModule(new LoggerModule());
            containerBuilder.RegisterModule(new AuthModule());
            containerBuilder.RegisterModule(new DbContextModule());

            Container = containerBuilder.Build();

            return new AutofacServiceProvider(Container);
        }
    }
}
