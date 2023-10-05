using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using Xenhey.BPM.Core.Net6.Implementation;
using Xenhey.BPM.Core.Net6;
using Newtonsoft.Json;

namespace AzureServiceBusToSQL
{
    public class cache
    {
        private HttpRequest _req;
        private NameValueCollection nvc = new NameValueCollection();
        [FunctionName("cache")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cache/{cacheid}")]
            HttpRequest req, string cacheid, ILogger log)
        {
            var input = JsonConvert.SerializeObject(new { cacheid });
            _req = req;

            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = input;
            _req.Headers.ToList().ForEach(item => { nvc.Add(item.Key, item.Value.FirstOrDefault()); });
            var results = orchrestatorService.Run(requestBody);
            return resultSet(results);
        }

        private ActionResult resultSet(string reponsePayload)
        {
            var returnContent = new ContentResult();
            var mediaSelectedtype = nvc.Get("Content-Type");
            returnContent.Content = reponsePayload;
            returnContent.ContentType = mediaSelectedtype;
            return returnContent;
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
