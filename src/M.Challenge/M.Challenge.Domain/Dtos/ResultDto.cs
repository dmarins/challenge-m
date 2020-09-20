using M.Challenge.Domain.Constants;

namespace M.Challenge.Domain.Dtos
{
    public class ResultDto
    {
        public ReturnType ReturnType { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public ResultDto Success(object data = null)
        {
            ReturnType = ReturnType.Success;
            Data = data;
            return this;
        }

        public ResultDto Fail()
        {
            ReturnType = ReturnType.Fail;
            Message = ErrorMessageConstants.Fail;
            return this;
        }

        public ResultDto InvalidContract()
        {
            ReturnType = ReturnType.InvalidContract;
            Message = ErrorMessageConstants.InvalidContract;
            return this;
        }
    }

    public enum ReturnType
    {
        Undefined,
        Success,
        Fail,
        InvalidContract
    }
}
