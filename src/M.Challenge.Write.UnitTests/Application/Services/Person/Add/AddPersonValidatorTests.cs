using AutoFixture.Idioms;
using FluentAssertions;
using M.Challenge.Write.Application.Services.Person.Add;
using M.Challenge.Write.Domain.Dtos;
using M.Challenge.Write.UnitTests.Config.AutoData;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace M.Challenge.Write.UnitTests.Application.Services.Person.Add
{
    public class AddPersonValidatorTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldHaveGuardClauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AddPersonValidator).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public async Task Sut_WhenPersonAlreadyExists_ReturnsInvalidContract(
            AddPersonValidator sut,
            PersonCrudDto dto,
            Write.Domain.Entities.Person person)
        {
            var commandResultDto = new CommandResultDto().InvalidContract();

            sut
                .PersonReadingRepository
                .GetBy(Arg.Any<Expression<Func<Write.Domain.Entities.Person, bool>>>())
                .Returns(person);

            var result = await sut.Process(dto);

            result.Data.Should().BeNull();
            result.Message.Should().Be(commandResultDto.Message);
            result.ReturnType.Should().Be(ReturnType.InvalidContract);

            sut.Logger
                .Received()
                .Warning("Já existe um cadastro para esse mesmo nome e sobrenome.");
        }

        [Theory, AutoNSubstituteData]
        public async Task Sut_WhenPersonNotExists_ReturnsCreated(
            AddPersonValidator sut,
            PersonCrudDto dto)
        {
            var commandResultDto = new CommandResultDto().Created();

            sut
                .PersonReadingRepository
                .GetBy(Arg.Any<Expression<Func<Write.Domain.Entities.Person, bool>>>())
                .ReturnsNull();
            sut
                .Decorated
                .Process(Arg.Any<PersonCrudDto>())
                .Returns(commandResultDto);

            var result = await sut.Process(dto);

            result.Data.Should().BeNull();
            result.Message.Should().Be(commandResultDto.Message);
            result.ReturnType.Should().Be(ReturnType.Created);
        }
    }
}
