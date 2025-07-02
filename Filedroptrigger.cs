// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Xenhey.BPM.Core.Net8;
using Xenhey.BPM.Core.Net8.Implementation;

namespace AzureServiceBusToSQL;

public class Filedroptrigger
{
    private readonly ILogger<Filedroptrigger> _logger;
    private NameValueCollection nvc = new NameValueCollection();

    public Filedroptrigger(ILogger<Filedroptrigger> logger)
    {
        _logger = logger;
    }

    [Function(nameof(Filedroptrigger))]
    public void Run([EventGridTrigger] EventGridEvent eventGridEvent)
    {
        string ApiKeyName = "x-api-key";
        _logger.LogInformation($"Received event: {eventGridEvent.EventType}");
        NameValueCollection nvc = new NameValueCollection
        {
            { ApiKeyName, "35C8400673BD4566AF97227BBC7A2754" }
        };
        var input = JsonConvert.SerializeObject(eventGridEvent);
        IOrchestrationService orchrestatorService = new RemoteOrchrestratorService(nvc);
        var processFiles = orchrestatorService.Run(input);

        

    }
}