using System.Collections.Specialized;
using System.IO;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net8;
using Xenhey.BPM.Core.Net8.Implementation;
using Microsoft.Azure.Functions.Worker;

namespace AzureServiceBusToSQL
{
    public class BlobTrigger
    {
        private readonly ILogger _logger;

        public BlobTrigger(ILogger<BlobTrigger> logger)
        {
            _logger = logger;
        }

        [Function("BlobTrigger")]
        public void Run([BlobTrigger("processed/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name)
        {
            string ApiKeyName = "x-api-key";
            _logger.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "2484F9382E974133A216F8E39BF4C389");
            nvc.Add("ContainerName", name);
            IOrchestrationService orchrestatorService = new RemoteOrchrestratorService(nvc);
            var processFiles = orchrestatorService.Run(myBlob);
            _logger.LogInformation(processFiles);
        }
    }
}
