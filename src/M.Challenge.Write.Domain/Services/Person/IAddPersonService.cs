using M.Challenge.Write.Domain.Dtos;
using System.Threading.Tasks;

namespace M.Challenge.Write.Domain.Services.Person
{
    public interface IAddPersonService
    {
        Task<ResultDto> Process(PersonCrudDto dto);
    }
}
