using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using People.Dto;
using People.Dto.Commands;
using People.Infrastructure.Database;
using People.Infrastructure.Domain;

namespace People.Infrastructure.Handlers
{
    public class AddPersonLastNameCommandHandler
    {
        private readonly AzureDb db;

        public AddPersonLastNameCommandHandler(AzureDb db)
        {
            this.db = db;
        }

        public async Task<int> HandleAsync(AddPersonLastNameCommand command)
        {
            var entity = await db.Set<PersonEntity>().AsQueryable()
                .FirstOrDefaultAsync(w => w.FirstName == command.FirstName);

            if (entity == null)
            {
                entity = PersonEntity.Create(
                    firstname: command.FirstName,
                    lastname: command.LastName
                );
                db.Set<PersonEntity>().Add(entity);
            }
            else
            {
                    entity.UpdateLastName(command.LastName);
            }

            await db.SaveChangesAsync();
            return entity.PersonId;
        }
    }
}