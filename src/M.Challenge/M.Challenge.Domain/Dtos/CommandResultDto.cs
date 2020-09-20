using System.Diagnostics.CodeAnalysis;

namespace M.Challenge.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class CommandResultDto : ResultDto
    {
        public CommandResultDto()
        {
        }

        public CommandResultDto(ReturnType returnType, object data, string message)
        {
            ReturnType = returnType;
            Data = data;
            Message = message;
        }
    }
}
