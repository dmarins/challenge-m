﻿using M.Challenge.Domain.Dtos;
using M.Challenge.Domain.Logger;
using M.Challenge.Domain.Persistence;
using M.Challenge.Domain.Repositories.Person;
using M.Challenge.Domain.Services.Person;
using System;
using System.Threading.Tasks;

namespace M.Challenge.Application.Services.Person.Add
{
    public class AddPerson : IAddPersonService
    {
        public ILogger Logger { get; }
        public IPersonWritingRepository PersonWritingRepository { get; }
        public IUnitOfWork UnitOfWork { get; }

        public AddPerson(ILogger logger,
            IPersonWritingRepository personWritingRepository,
            IUnitOfWork unitOfWork)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            PersonWritingRepository = personWritingRepository ?? throw new ArgumentNullException(nameof(personWritingRepository));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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

            var personStored = await PersonWritingRepository.Add(person);

            await UnitOfWork.Commit();

            return new CommandResultDto().Created(personStored);
        }
    }
}
