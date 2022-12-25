using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using People.Dto;
using People.Dto.Commands;
using People.Infrastructure.Database;
using People.Infrastructure.Domain;

namespace People.Infrastructure.Handlers
{
    public class DeletePersonCommandHandler
    {
        private readonly AzureDb db;

        public DeletePersonCommandHandler(AzureDb db)
        {
            this.db = db;
        }

        public async Task<int> HandleAsync(DeletePersonCommand command)
        {
            var entity = await db.Set<PersonEntity>().AsQueryable()
                .FirstOrDefaultAsync(w => w.PersonId == command.PersonId);

            if (entity != null)
            {
                    db.Set<PersonEntity>().Remove(entity);
            }


            await db.SaveChangesAsync();
            return entity.PersonId;
        }
    }
}