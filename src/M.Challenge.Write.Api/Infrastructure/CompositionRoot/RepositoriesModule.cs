using Autofac;
using M.Challenge.Write.Domain.Repositories.Person;
using M.Challenge.Write.Infrastructure.Repositories.Person;

namespace M.Challenge.Write.Api.Infrastructure.CompositionRoot
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
