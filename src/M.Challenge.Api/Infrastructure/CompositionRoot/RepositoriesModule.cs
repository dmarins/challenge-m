using Autofac;
using M.Challenge.Domain.Repositories.Person;
using M.Challenge.Infrastructure.Repositories.Person;

namespace M.Challenge.Api.Infrastructure.CompositionRoot
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PersonReadingRepository>()
                .As<IPersonReadingRepository>();
            builder
                .RegisterType<PersonWritingRepository>()
                .As<IPersonWritingRepository>();
        }
    }
}
