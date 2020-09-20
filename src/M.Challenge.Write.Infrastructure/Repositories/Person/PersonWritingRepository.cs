using M.Challenge.Write.Domain.Repositories.Person;
using M.Challenge.Write.Infrastructure.Persistence;
using M.Challenge.Write.Infrastructure.Repositories.Base;

namespace M.Challenge.Write.Infrastructure.Repositories.Person
{
    public class PersonWritingRepository : BasicWritingRepository<Domain.Entities.Person>, IPersonWritingRepository
    {
        public PersonWritingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
