using System.Threading.Tasks;

namespace M.Challenge.Infrastructure.Persistence.Config
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
