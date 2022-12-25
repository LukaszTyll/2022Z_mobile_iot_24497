using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using People.Dto;
using People.Dto.Commands;
using People.Infrastructure.Database;
using People.Infrastructure.Domain;

namespace People.Infrastructure.Handlers
{
    public class UpdatePersonCommandHandler
    {
        private readonly AzureDb db;

        public UpdatePersonCommandHandler(AzureDb db)
        {
            this.db = db;
        }

        public async Task<int> HandleAsync(UpdatePersonCommand command)
        {
            var entity = await db.Set<PersonEntity>().AsQueryable()
                .FirstOrDefaultAsync(w => w.PersonId == command.PersonId);

            if (entity != null)
            {
                    entity.UpdateFirstName(command.FirstName);
                    entity.UpdateLastName(command.LastName);
                    db.Set<PersonEntity>().Update(entity);
            }
            else{
                    entity = PersonEntity.Create(
                    firstname: command.FirstName,
                    lastname: command.LastName
                );
                db.Set<PersonEntity>().Add(entity);
            }

            await db.SaveChangesAsync();
            return entity.PersonId;
        }
    }
}