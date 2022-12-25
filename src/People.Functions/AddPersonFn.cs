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
using People.Dto.Commands;
using People.Infrastructure.Handlers;

namespace People.Functions
{
    public class AddPersonFn
    {
        private readonly AzureDb db;

        public AddPersonFn(AzureDb db)
        {
            this.db = db;
        }
        [FunctionName("AddPersonFn")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var command = JsonConvert.DeserializeObject<AddPersonLastNameCommand>(requestBody);
            var handler = new AddPersonLastNameCommandHandler(db);
            var id = await handler.HandleAsync(command);
            return new OkResult();
        }
    }
}
