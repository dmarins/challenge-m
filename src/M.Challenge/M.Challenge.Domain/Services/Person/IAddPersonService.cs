using M.Challenge.Domain.Dtos;
using System.Threading.Tasks;

namespace M.Challenge.Domain.Services.Person
{
    public interface IAddPersonService
    {
        Task<ResultDto> Process(PersonCrudDto dto);
    }
}
