using M.Challenge.Write.Domain.Repositories.Person;
using M.Challenge.Write.Infrastructure.Persistence;
using M.Challenge.Write.Infrastructure.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace M.Challenge.Write.Infrastructure.Repositories.Person
{
    public class PersonWritingRepository : BasicWritingRepository<Domain.Entities.Person>, IPersonWritingRepository
    {
        public PersonWritingRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Domain.Entities.Person> Add(Domain.Entities.Person obj)
        {
            obj.Id = Guid.NewGuid().ToString();

            return await base.Add(obj);
        }
    }
}
