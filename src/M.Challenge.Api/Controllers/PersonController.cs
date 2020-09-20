using M.Challenge.Api.Infrastructure.Attributes;
using M.Challenge.Api.Infrastructure.Auth.Policies;
using M.Challenge.Api.Infrastructure.Response;
using M.Challenge.Domain.Contracts.Request;
using M.Challenge.Domain.Dtos;
using M.Challenge.Domain.Services.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace M.Challenge.Api.Controllers
{
    [Route("person")]
    [ApiController]
    [Authorize(Policy = Policies.Writing)]
    public class PersonController : ControllerBase
    {
        public IResponseFactory ResponseFactory { get; }
        public IAddPersonService AddPersonService { get; }

        public PersonController(IResponseFactory responseFactory,
            IAddPersonService addPersonService)
        {
            ResponseFactory = responseFactory ?? throw new System.ArgumentNullException(nameof(responseFactory));
            AddPersonService = addPersonService ?? throw new System.ArgumentNullException(nameof(addPersonService));
        }

        [HttpPost]
        [ModelStateValidator]
        public async Task<IActionResult> AddPerson([FromBody] PersonRequest contract)
        {
            var dto = new PersonCrudDto
            {
                Name = contract.Name,
                LastName = contract.LastName,
                Ethnicity = contract.Ethnicity,
                Genre = contract.Genre,
                Filiation = contract.Filiation,
                Children = contract.Children,
                EducationLevel = contract.EducationLevel
            };

            return ResponseFactory
                .Return(await AddPersonService.Process(dto));
        }
    }
}
