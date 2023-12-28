using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using Xenhey.BPM.Core.Net8;
using Xenhey.BPM.Core.Net8.Implementation;

namespace AzureServiceBusToSQL
{
    public class FileChecker
    {
        private readonly ILogger _logger;

        public FileChecker(ILogger<FileParser> logger)
        {
            _logger = logger;
        }

        private NameValueCollection nvc = new NameValueCollection();

        [Function("FileChecker")]
        public void Run([TimerTrigger("%TimerInterval%")] TimerInfo myTimer)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string ApiKeyName = "x-api-key";
            //Ge file and update database information.
            nvc.Add(ApiKeyName, "3FB620B0E0FD4E8F93C9E4D839D00E1E");
            string requestBody = "{\"ProcessStarted\" : \"Yes\" }";
            var uploadFile = orchrestatorService.Run(requestBody);
            _logger.LogInformation(uploadFile);
        }

        private IOrchestrationService orchrestatorService
        {
            get
            {
                return new ManagedOrchestratorService(nvc);
            }
        }
    }
}
