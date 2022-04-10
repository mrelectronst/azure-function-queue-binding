using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Storage.Queue;
using azurefunctablebinding.Models;

namespace azurefunctablebinding.Functions
{
    public static class FunctionAzureQueueBinding
    {
        [FunctionName("FunctionAzureQueueBinding")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "postqueue")] HttpRequest req,
            [Queue("queuecustomer", Connection = "AzureLocalConnectionString")] CloudQueue cloudqueue,
            ILogger log)
        {
            cloudqueue.CreateIfNotExists();

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            CustomerDTO customer = JsonConvert.DeserializeObject<CustomerDTO>(requestBody);
            var customerString = JsonConvert.SerializeObject(customer);

            CloudQueueMessage cloudQueueMessage = new CloudQueueMessage(customerString);
            await cloudqueue.AddMessageAsync(cloudQueueMessage);

            return new OkObjectResult(customer);
        }
    }
}
