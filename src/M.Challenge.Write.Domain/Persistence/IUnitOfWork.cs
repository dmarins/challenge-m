using System.Threading.Tasks;

namespace M.Challenge.Write.Domain.Persistence
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
