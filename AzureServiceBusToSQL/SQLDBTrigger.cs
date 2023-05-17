using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net6;
using Xenhey.BPM.Core.Net6.Implementation;

namespace AzureServiceBusToSQL
{
    public static class SQLDBTrigger
    {
        [FunctionName("SQLDBTrigger")]
        public static void Run([ServiceBusTrigger("request", "sqlmesssage", Connection = "ServiceBusConnectionString")] string mySbMsg, Int32 deliveryCount, DateTime enqueuedTimeUtc, string messageId, ILogger log)
        {
            string ApiKeyName = "x-api-key";
            log.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "43EFE991E8614CFB9EDECF1B0FDED37C");
            IOrchestrationService orchrestatorService = new ManagedOrchestratorService(nvc);
            var processFiles = orchrestatorService.Run(mySbMsg);
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");
        }
    }
}
