using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using People.Infrastructure.Database;
using People.Infrastructure.Handlers;
using People.Dto.Queries;

namespace People.Functions
{
    public class GetPersonLastNameFn
    {
        private readonly AzureDb db;

        public GetPersonLastNameFn(AzureDb db)
        {
            this.db = db;
        }

        [FunctionName("GetPersonLastNameFn")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var query = new GetPersonLastNameQuery();
            var handler = new GetPersonLastNameQueryHandler(db);
            var result = await handler.HandleAsync(query);
            return new OkObjectResult(result);
        }
    }
}
