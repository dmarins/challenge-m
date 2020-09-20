using M.Challenge.Domain.Repositories.Base;
using M.Challenge.Infrastructure.Persistence.Config;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace M.Challenge.Infrastructure.Repositories.Base
{
    public class BasicWritingRepository<T> : IBasicWritingRepository<T> where T : class
    {
        public IDbContext DbContext { get; }
        public IMongoCollection<T> DbSet { get; }

        public BasicWritingRepository(IDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = dbContext.GetCollection<T>(nameof(T));
        }

        public virtual Task<T> Add(T entity)
        {
            DbContext.AddCommand(async () => await DbSet.InsertOneAsync(entity));

            return Task.FromResult(entity);
        }
    }
}
