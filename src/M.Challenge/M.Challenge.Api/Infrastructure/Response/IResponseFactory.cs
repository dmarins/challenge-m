using M.Challenge.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace M.Challenge.Api.Infrastructure.Response
{
    public interface IResponseFactory
    {
        ObjectResult Return(ResultDto dto);
    }
}
