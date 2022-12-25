using Microsoft.EntityFrameworkCore;
using People.Infrastructure.Domain;

namespace People.Infrastructure.Database
{
    public class AzureDb : DbContext
    {
        public AzureDb(DbContextOptions<AzureDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entity = modelBuilder.Entity<PersonEntity>();
            entity.ToTable("People");
            entity.Property(p => p.FirstName).HasMaxLength(250).IsRequired();
            entity.HasIndex(i => i.FirstName);
        }
    }
}