using AutoFixture.Idioms;
using FluentAssertions;
using M.Challenge.Write.Api.Controllers;
using M.Challenge.Write.Domain.Constants;
using M.Challenge.Write.Domain.Contracts.Request;
using M.Challenge.Write.Domain.Dtos;
using M.Challenge.Write.UnitTests.Config.AutoData;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace M.Challenge.Write.UnitTests.Api.Controllers
{
    public class PersonControllerTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldHaveGuardClauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(PersonController).GetConstructors());
        }

        [Theory]
        [InlineNSubstituteData(ReturnType.InvalidContract, null, (int)HttpStatusCode.BadRequest, ErrorMessageConstants.InvalidContract)]
        [InlineNSubstituteData(ReturnType.Fail, null, (int)HttpStatusCode.InternalServerError, ErrorMessageConstants.Fail)]
        [InlineNSubstituteData(ReturnType.Created, null, (int)HttpStatusCode.Created, null)]
        public async Task Sut_WhenAddPerson_ShouldPerformAsExpected(
            ReturnType expectedReturnType,
            object expectedData,
            int expectedStatusCode,
            string expectedMessage,
            PersonController sut,
            PersonRequest contract)
        {
            var expectedCommandResultDto = new CommandResultDto(
                expectedReturnType,
                expectedData,
                expectedMessage);

            var objectResult =
                new ObjectResult(expectedMessage)
                {
                    StatusCode = expectedStatusCode
                };

            sut.ResponseFactory
                .Return(Arg.Any<CommandResultDto>())
                .Returns(objectResult);

            sut.AddPersonService
                .Process(Arg.Any<PersonCrudDto>())
                .Returns(expectedCommandResultDto);

            var result = await sut.AddPerson(contract);

            result
                .As<ObjectResult>()
                .StatusCode
                .Should()
                .Be(expectedStatusCode);

            result
                .As<ObjectResult>()
                .Value
                .Should()
                .Be(expectedMessage);
        }
    }
}
