using M.Challenge.Domain.Repositories.Person;
using M.Challenge.Infrastructure.Persistence.Config;
using M.Challenge.Infrastructure.Repositories.Base;

namespace M.Challenge.Infrastructure.Repositories.Person
{
    public class PersonReadingRepository : BasicReadingRepository<Domain.Entities.Person>, IPersonReadingRepository
    {
        public PersonReadingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
