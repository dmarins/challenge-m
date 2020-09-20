using M.Challenge.Domain.Repositories.Person;
using M.Challenge.Infrastructure.Persistence.Config;
using M.Challenge.Infrastructure.Repositories.Base;

namespace M.Challenge.Infrastructure.Repositories.Person
{
    public class PersonWritingRepository : BasicWritingRepository<Domain.Entities.Person>, IPersonWritingRepository
    {
        public PersonWritingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
