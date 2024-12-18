using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
     .ConfigureServices(services =>
 {
     services.AddApplicationInsightsTelemetryWorkerService();
     services.ConfigureFunctionsApplicationInsights();
     services.Configure<KestrelServerOptions>(options =>  
    {  
        options.AllowSynchronousIO = true;  
    });  
 })
    .Build();

host.Run();
