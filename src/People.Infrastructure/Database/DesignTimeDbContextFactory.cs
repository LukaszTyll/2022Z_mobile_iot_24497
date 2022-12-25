using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace People.Infrastructure.Database
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AzureDb>
    {
        public AzureDb CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AzureDb>();
            var connectionString = configuration.GetConnectionString("AzureDb");
            builder.UseSqlServer(connectionString);
            return new AzureDb(builder.Options);
        }
    }
}