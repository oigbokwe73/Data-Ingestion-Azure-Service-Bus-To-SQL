using System.Collections.Specialized;
using System.IO;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net8;
using Xenhey.BPM.Core.Net8.Implementation;
using Microsoft.Azure.Functions.Worker;

namespace AzureServiceBusToSQL
{
    public class FileParser
    {
        private readonly ILogger _logger;

        public FileParser(ILogger<FileParser> logger)
        {
            _logger = logger;
        }

        [Function("FileParser")]
        public void Run([BlobTrigger("pickup/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name)
        {
            string ApiKeyName = "x-api-key";
            _logger.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "99F77BEF300E4660A63A939ADD0BCF68");
            nvc.Add("ContainerName", name);
            IOrchestrationService orchrestatorService = new ManagedOrchestratorService(nvc);
            var processFiles = orchrestatorService.Run(myBlob);
            _logger.LogInformation(processFiles);
        }
    }
}
