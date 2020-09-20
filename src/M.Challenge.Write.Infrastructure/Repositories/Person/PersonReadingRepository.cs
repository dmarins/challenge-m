using M.Challenge.Write.Domain.Repositories.Person;
using M.Challenge.Write.Infrastructure.Persistence;
using M.Challenge.Write.Infrastructure.Repositories.Base;

namespace M.Challenge.Write.Infrastructure.Repositories.Person
{
    public class PersonReadingRepository : BasicReadingRepository<Domain.Entities.Person>, IPersonReadingRepository
    {
        public PersonReadingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
