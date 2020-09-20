using M.Challenge.Write.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace M.Challenge.Write.Api.Infrastructure.Response
{
    public class ResponseFactory : IResponseFactory
    {
        public ObjectResult Return(ResultDto dto)
        {
            return dto.ReturnType switch
            {
                ReturnType.Success => new ObjectResult(dto.Data)
                {
                    StatusCode = (int)HttpStatusCode.OK
                },
                ReturnType.Fail => new ObjectResult(dto.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                },
                ReturnType.InvalidContract => new ObjectResult(dto.Message)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                },
                ReturnType.Created => new ObjectResult(dto.Data)
                {
                    StatusCode = (int)HttpStatusCode.Created
                },
                _ => new ObjectResult(dto.Message)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
            };
        }
    }
}
