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
            nvc.Add(ApiKeyName, "35C8400673BD4566AF97227BBC7A2754");
            nvc.Add("ContainerName", name);
            IOrchestrationService orchrestatorService = new RemoteOrchrestratorService(nvc);
            var processFiles = orchrestatorService.Run(myBlob);
            _logger.LogInformation(processFiles);
        }
    }
}
