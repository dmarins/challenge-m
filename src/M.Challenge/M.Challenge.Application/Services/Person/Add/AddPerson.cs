using M.Challenge.Domain.Dtos;
using M.Challenge.Domain.Logger;
using M.Challenge.Domain.Services.Person;
using System;
using System.Threading.Tasks;

namespace M.Challenge.Application.Services.Person.Add
{
    public class AddPerson : IAddPersonService
    {
        public ILogger Logger { get; }

        public AddPerson(ILogger logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResultDto> Process(PersonCrudDto dto)
        {
            var person = new Domain.Entities.Person(
                dto.Name,
                dto.LastName,
                dto.Ethnicity,
                dto.Genre,
                dto.EducationLevel);

            foreach (var filiation in dto.Filiation)
            {
                person.AddFilliation(filiation);
            }

            foreach (var child in dto.Children)
            {
                person.AddChild(child);
            }

            // persistir a pessoa

            return new CommandResultDto().Created();
        }
    }
}
