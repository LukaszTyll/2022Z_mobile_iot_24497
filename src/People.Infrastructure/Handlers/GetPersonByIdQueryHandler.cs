using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using People.Dto.Models;
using People.Dto.Queries;
using People.Infrastructure.Database;
using People.Infrastructure.Domain;

namespace People.Infrastructure.Handlers
{
    public class GetPersonByIdQueryHandler
    {
        private readonly AzureDb db;

        public GetPersonByIdQueryHandler(AzureDb db)
        {
            this.db = db;
        }

         public async Task<IEnumerable<Person>> HandleAsync(GetPersonByIdQuery query)
        {
            // var entity = await db.Set<PersonEntity>().AsNoTracking()
            //     .Select(w => w.PersonId == query.PersonId).ToQueryString();

                    var entity =  await db.Set<PersonEntity>().AsQueryable()
                    .Select(s => new Person
                {
                    PersonId = s.PersonId,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                })
                    .Where(s => s.PersonId == query.PersonId).ToListAsync();
            return entity;
        }
    }
}