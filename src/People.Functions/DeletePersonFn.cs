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
    public class DeletePersonFn
    {
        private readonly AzureDb db;

        public DeletePersonFn(AzureDb db)
        {
            this.db = db;
        }
        [FunctionName("DeletePersonFn")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var command = JsonConvert.DeserializeObject<DeletePersonCommand>(requestBody);
            var handler = new DeletePersonCommandHandler(db);
            var id = await handler.HandleAsync(command);
            return new OkResult();
        }
    }
}
