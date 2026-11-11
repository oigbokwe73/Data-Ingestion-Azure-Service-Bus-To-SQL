using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using Xenhey.BPM.Core.Net8.Implementation;
using Xenhey.BPM.Core.Net8;
using Newtonsoft.Json;

namespace AzureServiceBusToSQL
{
    public class upload
    {
        private readonly ILogger _logger;

        public upload(ILogger<upload> logger)
        {
            _logger = logger;
        }

        private HttpRequest _req;
        private NameValueCollection nvc = new NameValueCollection();
        [Function("upload")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequest req)
        {
            _req = req;

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            _req.Headers.ToList().ForEach(item => { nvc.Add(item.Key, item.Value.FirstOrDefault()); });
            var response = new List<Dictionary<string,string>>();
            var formdata = await req.ReadFormAsync();
            var file = req.Form.Files;
            foreach (var item in file)
            {
                nvc.Add("FileName", item.FileName);
                nvc.Add("FileContentType", item.ContentType);
                nvc.Add("FileLength", item.Length.ToString());
                var results = orchrestatorService.Run(item.OpenReadStream());
                var fileDetails = JsonConvert.DeserializeObject<Dictionary<string,string>>(results);
                fileDetails.Add("FileName",item.FileName);
                response.Add(fileDetails);
                nvc.Remove("FileName");
                nvc.Remove("FileContentType");
                nvc.Remove("FileLength");
            }

            return resultSet(JsonConvert.SerializeObject(response));

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
                return new RemoteOrchrestratorService(nvc);
            }
        }

    }
}
