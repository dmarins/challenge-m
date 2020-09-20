using M.Challenge.Write.Domain.Dtos;
using M.Challenge.Write.Domain.Logger;
using M.Challenge.Write.Domain.Repositories.Person;
using M.Challenge.Write.Domain.Services.Person;
using System;
using System.Threading.Tasks;

namespace M.Challenge.Write.Application.Services.Person.Add
{
    public class AddPersonValidator : IAddPersonService
    {
        public ILogger Logger { get; }
        public IPersonReadingRepository PersonReadingRepository { get; }
        public IAddPersonService Decorated { get; }

        public AddPersonValidator(
            ILogger logger,
            IPersonReadingRepository personReadingRepository,
            IAddPersonService decorated)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            PersonReadingRepository = personReadingRepository ?? throw new ArgumentNullException(nameof(personReadingRepository));
            Decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }

        public async Task<ResultDto> Process(PersonCrudDto dto)
        {
            var personStored = await PersonReadingRepository
                .GetBy(p => p.Name == dto.Name && p.LastName == dto.LastName);

            if (personStored != null)
            {
                Logger.Warning("Uma pessoa já foi cadastrada com o mesmo nome e sobrenome.");
                return new CommandResultDto().InvalidContract();
            }

            return await Decorated.Process(dto);
        }
    }
}
