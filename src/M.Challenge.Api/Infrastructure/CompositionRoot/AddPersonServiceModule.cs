using Autofac;
using M.Challenge.Application.Services.Person.Add;
using M.Challenge.Domain.Services.Person;

namespace M.Challenge.Api.Infrastructure.CompositionRoot
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
