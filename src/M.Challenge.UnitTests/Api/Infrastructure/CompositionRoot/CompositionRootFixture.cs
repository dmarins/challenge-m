using Autofac;
using M.Challenge.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace M.Challenge.UnitTests.Api.Infrastructure.CompositionRoot
{
    public class CompositionRootFixture
    {
        public IContainer Container { get; }

        public CompositionRootFixture()
        {
            var configuration = Substitute.For<IConfigurationRoot>();
            var services = new ServiceCollection();
            var startup = new Startup(configuration);

            startup.RegisterDependencies(services);

            Container = startup.Container;
        }
    }
}
