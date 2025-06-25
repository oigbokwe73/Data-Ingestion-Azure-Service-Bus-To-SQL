using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net8;
using Xenhey.BPM.Core.Net8.Implementation;
using Microsoft.Azure.Functions.Worker;

namespace AzureServiceBusToSQL
{
    public class SQLDBTrigger
    {
        private readonly ILogger _logger;

        public SQLDBTrigger(ILogger<SQLDBTrigger> logger)
        {
            _logger = logger;
        }

        [Function("SQLDBTrigger")]
        public void Run([ServiceBusTrigger("request", "sqlmessage", Connection = "ServiceBusConnectionString")] string mySbMsg, Int32 deliveryCount, DateTime enqueuedTimeUtc, string messageId)
        {
            string ApiKeyName = "x-api-key";
            _logger.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "269CA9B3A0B542E3A5BB713005D591F7");
            IOrchestrationService orchrestatorService = new RemoteOrchrestratorService(nvc);
            var processFiles = orchrestatorService.Run(mySbMsg);
            _logger.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            _logger.LogInformation($"DeliveryCount={deliveryCount}");
            _logger.LogInformation($"MessageId={messageId}");
        }
    }
}
