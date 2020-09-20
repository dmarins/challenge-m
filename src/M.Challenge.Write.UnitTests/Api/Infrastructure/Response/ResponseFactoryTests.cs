using FluentAssertions;
using M.Challenge.Write.Api.Infrastructure.Response;
using M.Challenge.Write.Domain.Constants;
using M.Challenge.Write.Domain.Dtos;
using M.Challenge.Write.UnitTests.Config.AutoData;
using System.Net;
using Xunit;

namespace M.Challenge.Write.UnitTests.Api.Infrastructure.Response
{
    public class ResponseFactoryTests
    {
        [Theory]
        [InlineNSubstituteData(ReturnType.Success, null, (int)HttpStatusCode.OK, null)]
        [InlineNSubstituteData(ReturnType.InvalidContract, null, (int)HttpStatusCode.BadRequest, ErrorMessageConstants.InvalidContract)]
        [InlineNSubstituteData(ReturnType.Fail, null, (int)HttpStatusCode.InternalServerError, ErrorMessageConstants.Fail)]
        [InlineNSubstituteData(ReturnType.Undefined, null, (int)HttpStatusCode.BadRequest, ErrorMessageConstants.InvalidContract)]
        public void Sut_WhenFactoryReturnsAccordingToTheDto_ShouldPerformAsExpected(
            ReturnType expectedReturnType,
            object expectedData,
            int expectedStatusCode,
            string expectedMessage,
            ResponseFactory sut)
        {
            var expectedQueryResultDto = new CommandResultDto(
                expectedReturnType,
                expectedData,
                expectedMessage);

            var result = sut.Return(expectedQueryResultDto);

            result
                .StatusCode
                .Should()
                .Be(expectedStatusCode);

            result
                .Value
                .Should()
                .Be(expectedMessage);
        }
    }
}
