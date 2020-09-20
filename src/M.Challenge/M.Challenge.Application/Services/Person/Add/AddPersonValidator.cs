using M.Challenge.Domain.Dtos;
using M.Challenge.Domain.Logger;
using M.Challenge.Domain.Services.Person;
using System.Threading.Tasks;

namespace M.Challenge.Application.Services.Person.Add
{
    public class AddPersonValidator : IAddPersonService
    {
        public ILogger Logger { get; }
        public IAddPersonService Decorated { get; }

        public AddPersonValidator(ILogger logger, IAddPersonService decorated)
        {
            Logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            Decorated = decorated ?? throw new System.ArgumentNullException(nameof(decorated));
        }

        public async Task<ResultDto> Process(PersonCrudDto dto)
        {
            // recuperar pessoa pelo nome e sobrenome

            // se já existe uma pessoa cadastrada, logar warning e retornar invalid contract

            return await Decorated.Process(dto);
        }
    }
}
