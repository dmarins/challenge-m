using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace M.Challenge.Write.Infrastructure.Persistence
{
    public interface IDbContext
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
