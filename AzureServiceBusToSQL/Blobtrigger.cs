using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core;
using Xenhey.BPM.Core.Implementation;

namespace AzureServiceBusToSQL
{
    public static class BlobTrigger
    {
        [FunctionName("BlobTrigger")]
        public static void Run([BlobTrigger("processed/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            string ApiKeyName = "x-api-key";
            log.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "43EFE991E8614CFB9EDECF1B0FDED37D");
            IOrchrestatorService orchrestatorService = new ManagedOrchestratorService(nvc);
            var processFiles = orchrestatorService.Run(myBlob);
        }
    }
}
