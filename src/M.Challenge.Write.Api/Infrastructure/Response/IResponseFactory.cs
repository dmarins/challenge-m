using M.Challenge.Write.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace M.Challenge.Write.Api.Infrastructure.Response
{
    public interface IResponseFactory
    {
        ObjectResult Return(ResultDto dto);
    }
}
