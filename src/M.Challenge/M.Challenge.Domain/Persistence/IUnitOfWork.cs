using System.Threading.Tasks;

namespace M.Challenge.Domain.Persistence
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
