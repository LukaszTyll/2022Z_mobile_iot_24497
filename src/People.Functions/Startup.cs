using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using People.Infrastructure.Database;

[assembly: FunctionsStartup(typeof(People.Functions.Startup))]

namespace People.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<AzureDb>(options =>
            {
                var connectionString = System.Environment.GetEnvironmentVariable("AzureDb");
                options.UseSqlServer(connectionString);
            });
        }
    }
}