using System;
using System.Collections.Specialized;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net8;
using Xenhey.BPM.Core.Net8.Implementation;
using Microsoft.Azure.Functions.Worker;

namespace AzureServiceBusToSQL
{
    public class NoSQLTrigger
    {
        private readonly ILogger _logger;

        public NoSQLTrigger(ILogger<NoSQLTrigger> logger)
        {
            _logger = logger;
        }

        [Function("NoSQLTrigger")]
        public void Run([ServiceBusTrigger("request", "nosqlmessage", Connection = "ServiceBusConnectionString")] string mySbMsg, Int32 deliveryCount, DateTime enqueuedTimeUtc, string messageId)
        {
            string ApiKeyName = "x-api-key";
            _logger.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "00766FE7DC3E469CB8E3416B9BC6A26C");
            IOrchestrationService orchrestatorService = new RemoteOrchrestratorService(nvc);
            var processFiles = orchrestatorService.Run(mySbMsg);
            _logger.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            _logger.LogInformation($"DeliveryCount={deliveryCount}");
            _logger.LogInformation($"MessageId={messageId}");
        }
    }
}
