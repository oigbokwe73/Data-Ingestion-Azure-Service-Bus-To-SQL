// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using System.IO;
using System.Text.Json;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net8.Implementation;
using Xenhey.BPM.Core.Net8;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Microsoft.Azure.Management.Sql.Fluent.Models;

namespace AzureServiceBusToSQL;

public class FileParser
{
    private readonly ILogger<FileParser> _logger;
    private NameValueCollection nvc = new NameValueCollection();

    public FileParser(ILogger<FileParser> logger)
    {
        _logger = logger;
    }

    [Function(nameof(FileParser))]
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