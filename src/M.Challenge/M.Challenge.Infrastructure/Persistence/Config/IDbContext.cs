using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace M.Challenge.Infrastructure.Persistence.Config
{
    public interface IDbContext
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
