using Autofac;
using M.Challenge.Write.Application.Services.Person.Add;
using M.Challenge.Write.Domain.Services.Person;

namespace M.Challenge.Write.Api.Infrastructure.CompositionRoot
{
    public class AddPersonServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddPerson>().As<IAddPersonService>();
            builder.RegisterDecorator<AddPersonValidator, IAddPersonService>();
            builder.RegisterDecorator<AddPersonExceptionHandler, IAddPersonService>();
        }
    }
}
