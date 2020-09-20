using M.Challenge.Write.Api.Infrastructure.Response;
using M.Challenge.Write.Domain.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace M.Challenge.Write.Api.Infrastructure.Filters
{
    public class ModelStateValidatorFilter : IActionFilter
    {
        public IResponseFactory ResponseFactory { get; }

        public ModelStateValidatorFilter(IResponseFactory responseFactory)
        {
            ResponseFactory = responseFactory ?? throw new ArgumentNullException(nameof(responseFactory));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                context.Result = ResponseFactory.Return(new ResultDto().InvalidContract());
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
