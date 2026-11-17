using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using Xenhey.BPM.Core.Net8.Implementation;
using Xenhey.BPM.Core.Net8;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker;

namespace AzureServiceBusToSQL
{
    public class getdocument
    {
        private readonly ILogger _logger;

        public getdocument(ILogger<getdocument> logger)
        {
            _logger = logger;
        }

        private HttpRequest _req;
        private NameValueCollection nvc = new NameValueCollection();
        [Function("getdocument")]  
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "doc/{docid}")]
            HttpRequest req, string docid)
        {
            var input = JsonConvert.SerializeObject(new { docid });
            _req = req;
            string ApiKeyName = "x-api-key";
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = input;
            nvc.Add(ApiKeyName, "B44CBDDB3AE14913A2B0AD98193CFDC3");
            var results = orchrestatorService.ReturnFile(requestBody);
            return resultSet(results);
        }

        private ActionResult resultSet(byte[] reponsePayload)
        {
            var mediaSelectedtype = nvc.Get("Content-Type");
            var returnContent = new FileContentResult(reponsePayload, mediaSelectedtype);
            return returnContent;
        }
        private IOrchestrationService orchrestatorService
        {
            get
            {
                return new RemoteOrchrestratorService(nvc);
            }
        }

    }
}
