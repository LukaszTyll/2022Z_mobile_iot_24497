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
    public class GetPersonLastNameQueryHandler
    {
        private readonly AzureDb db;

        public GetPersonLastNameQueryHandler(AzureDb db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Person>> HandleAsync(GetPersonLastNameQuery query)
        {
            var entities = await db.Set<PersonEntity>()
                .AsNoTracking()
                .Select(s => new Person
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                })
                .OrderByDescending(by => by.LastName)
                .ToListAsync();

            return entities;
        }
    }
}