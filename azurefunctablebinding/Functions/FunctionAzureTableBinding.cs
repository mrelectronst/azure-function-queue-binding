using azurefunctablebinding.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

//Before start make sure that the dependency is installed "Install-Package Microsoft.Azure.WebJobs.Extensions.Storage -Version 4.0.5"
//Fill AzureRemoteConnectionString

namespace azurefunctablebinding
{
    public static class FunctionAzureTableBinding
    {
        [FunctionName("InsertProduct")]
        public static async Task<IActionResult> PostProduct(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "postproduct")] HttpRequest req,
            [Table("Products",Connection = "AzureLocalConnectionString")] CloudTable cloudtable,
            ILogger log)
        {
            cloudtable.CreateIfNotExists();

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ProductDTO product = JsonConvert.DeserializeObject<ProductDTO>(requestBody);

            TableOperation tableOperation = TableOperation.Insert(product);

            await cloudtable.ExecuteAsync(tableOperation);
           
            return new OkObjectResult(product);
        }

    }
}
