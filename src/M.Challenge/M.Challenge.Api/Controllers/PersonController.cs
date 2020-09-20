using M.Challenge.Api.Infrastructure.Attributes;
using M.Challenge.Api.Infrastructure.Auth.Policies;
using M.Challenge.Api.Infrastructure.Response;
using M.Challenge.Domain.Contracts.Request;
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

        public PersonController(IResponseFactory responseFactory)
        {
            ResponseFactory = responseFactory ?? throw new System.ArgumentNullException(nameof(responseFactory));
        }

        [HttpPost]
        [ModelStateValidator]
        public async Task<IActionResult> AddPerson([FromBody] PersonRequest contract)
        {
            return ResponseFactory
                .Return(new Domain.Dtos.ResultDto().Success());
        }
    }
}
