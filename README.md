
# Azure Service Bus To SQL


## Architecture Diagram

![image](https://user-images.githubusercontent.com/15838780/226928604-4340b682-0e13-44bc-b239-6b91a29f678a.png)


## Session Recorded 

[Session Video - 10/25/2023](https://pbsdatastore.blob.core.windows.net/training/TrainingInfo/video1200836733.mp4?sp=r&st=2023-11-27T18:00:59Z&se=2024-11-28T02:00:59Z&spr=https&sv=2022-11-02&sr=b&sig=RVsUNFsr22S2LUGszi5GTk8J4bSnn%2B8uKqOLn7KPaFs%3D)

[Session Video - 06/04/2023](https://storageaccountparknb028.blob.core.windows.net/training/traininginfo/video1910447954.mp4?sp=r&st=2023-04-16T02:33:29Z&se=2024-04-16T10:33:29Z&spr=https&sv=2021-12-02&sr=b&sig=YN7SnRVnsOXW0ybvhf9%2FLFImdiH%2BgFfPEZj5wMrf0Bc%3D)

[Session Video - 07/05/2023](https://pbsdatastore.blob.core.windows.net/training/TrainingInfo/video1944747398.mp4?sp=r&st=2023-07-19T22:57:55Z&se=2024-07-20T06:57:55Z&spr=https&sv=2022-11-02&sr=b&sig=hfuhIKhzVAnYPH8dJckzKVx%2BqMUqaSf6alYkfeniNb0%3D)

[Session Video - 08/24/2023](https://pbsdatastore.blob.core.windows.net/training/TrainingInfo/video1985794332.mp4?sp=r&st=2023-08-24T16:42:08Z&se=2024-08-25T00:42:08Z&spr=https&sv=2022-11-02&sr=b&sig=9B0W%2F%2BHHm%2BpUvwpNviRbjUahuwUAUtDCyDdpmUg6YOI%3D
)

[Session Video - 10/11/2023](https://pbsdatastore.blob.core.windows.net/training/TrainingInfo/video1584605133.mp4?sp=r&st=2023-10-25T21:21:26Z&se=2024-10-26T05:21:26Z&spr=https&sv=2022-11-02&sr=b&sig=qi2vWGpXxx1IoTWPqY71q9hlRyQFpVq%2BDNu8w9vCR5k%3D)

[Session Video - 10/25/2023](https://pbsdatastore.blob.core.windows.net/training/TrainingInfo/video1029088020.mp4?sp=r&st=2023-10-26T22:01:35Z&se=2024-10-27T06:01:35Z&spr=https&sv=2022-11-02&sr=b&sig=lpaBwJdyKzTLSs6cRggG4109o46Ycz9Lgi1vJegPxxY%3D)

[Session Video - 10/25/2023](https://pbsdatastore.blob.core.windows.net/training/TrainingInfo/video1029088020.mp4?sp=r&st=2023-10-26T22:01:35Z&se=2024-10-27T06:01:35Z&spr=https&sv=2022-11-02&sr=b&sig=lpaBwJdyKzTLSs6cRggG4109o46Ycz9Lgi1vJegPxxY%3D)







Set Up Steps 

Creating a serverless API using Azure that leverages Service Bus to communicate with an SQL Database involves several steps. Here's a high-level overview of how you can set this up:

1. **Set Up Azure SQL Database**:
   - Create an Azure SQL Database instance.
   - Set up the necessary tables and schemas you'll need for your application.

2. **Create Azure Service Bus**:
   - Set up an Azure Service Bus namespace.
   - Within the namespace, create a queue or topic (based on your requirement).

3. **Deploy Serverless API using Azure Functions**:
   - Create a new Azure Function App.
   - Develop an HTTP-triggered function that will act as your API endpoint.
   - In this function, when data is received, send a message to the Service Bus queue or topic.

4. **Deploy 2 Service Bus Triggered Function**:
   - Create another Azure Function that is triggered by the Service Bus queue or topic.
   - This function will read the message from the Service Bus and process it. The processing might involve parsing the message and inserting the data into the Azure SQL Database.

5. **Deploy a Timer Triggered Function**:
   - Create another Azure Function that is triggered when a file is dropped in a container.
   - This function will stream in a file, read it and place on the service bus topic.

6. **Implement Error Handling**:
   - Ensure that you have error handling in place. If there's a failure in processing the message and inserting it into the database, you might want to log the error or move the message to a dead-letter queue.

7. **Secure Your Functions**:
   - Ensure that your HTTP-triggered function (API endpoint) is secured, possibly using Azure Active Directory or function keys.

8. **Optimize & Monitor**:
   - Monitor the performance of your functions using Azure Monitor and Application Insights.
   - Optimize the performance, scalability, and cost by adjusting the function's plan (Consumption Plan, Premium Plan, etc.) and tweaking the configurations.

9. **Deployment**:
   - Deploy your functions to the Azure environment. You can use CI/CD pipelines using tools like Azure DevOps or GitHub Actions for automated deployments.

By following these steps, you'll have a serverless API in Azure that uses Service Bus as a mediator to process data and store it in an SQL Database. This architecture ensures decoupling between data ingestion and processing, adding a layer of resilience and scalability to your solution.


## Appplication Setting 

|Key|Value | Comment|
|:----|:----|:----|
|AzureWebJobsStorage|[CONNECTION STRING]|RECOMMENDATION :  store in AzureKey Vault.|
|ConfigurationPath| [CONFIGURATION FOLDER PATH] |Folder is optional
|ApiKeyName|[API KEY NAME]|Will be passed in the header  :  the file name of the config.
|AppName| [APPLICATION NAME]| This is the name of the Function App, used in log analytics|
|StorageAcctName|[STORAGE ACCOUNT NAME]|Example  "AzureWebJobsStorage"|
|ServiceBusConnectionString|[SERVICE BUS CONNECTION STRING]|Example  "ServiceBusConnectionString".  Recommmended to store in Key vault.|
|DatabaseConnection|[DATABASE CONNECTION STRING]|Example  "DatabaseConnection". Recommmended to store in Key vault.|
|TimerInterval|[TIMER_INTERVAL]|Example  "0 */1 * * * *" 1 MIN|


> **Note:**  Look at the configuration file in the **Config** Folder and created a Table to record information.

## Configuration Files 

> **Note:** The **Configuration** is located in the  FunctionApp  in a **Config** Folder.

|FileName|Description|
|:----|:----|
|43EFE991E8614CFB9EDECF1B0FDED37A.json| **Upload File** Parse CSV file --> Write Batched Files To Storage|
|43EFE991E8614CFB9EDECF1B0FDED37D.json| **Upload File** Parse JSON/CSV Directly to NO SQL DB|
|43EFE991E8614CFB9EDECF1B0FDED37C.json| **Service Bus Trigger for SQL DB** | Receive JSON payload and insert into SQL DB|
|43EFE991E8614CFB9EDECF1B0FDED37F.json| **Service Bus Trigger for No SQL DB** | Receive JSON payload and insert into NO SQL DB|
|43EFE991E8614CFB9EDECF1B0FDED37E.json| **Blob Trigger** Send parsed/sharded file  to Send to Service Bus|
|43EFE991E8614CFB9EDECF1B0FDED37B.json| **Search Resullt from NO SQLDB** |
|43EFE991E8614CFB9EDECF1B0FDED37G.json| **Search SQL DB. Return resultset** |
|3FB620B0E0FD4E8F93C9E4D839D00E1E.json| **Copy File from SFTP into the pickup folder** |
|3FB620B0E0FD4E8F93C9E4D839D00E1F.json| **Create a new Record in NoSQL Database** |
|CC244934898F46789734A9437B6F76CA.json| Encode Payload Request |
|6B427917E36A4DA281D57F9A64AD9D55.json| Get reports from DB  |


> Create the following blob containers and share in azure storage

|ContainerName|Description|
|:----|:----|
|config|Location for the configuration files|
|pickup|Thes are files that are copied from the SFTP share and dropped in the pickup container |
|processed|These are files the have been parsed and dropped in th processed container|

|Table|Description|
|:----|:----|
|csvbatchfiles|Track the CSV parsed files|
|training[YYYYMMDD]|N0 SQL DataStore|


|Share|Description|
|:----|:----|
|training[YYYYMMDD]|Create a share location for SFTP to drop files|

## Service Bus Subscription information

|Subscription Name|Description|
|:----|:----|
|nosqlmessage|Receive messages and store in NoSQL DB|
|sqlmessage|Receive messages and store in SQL DB|

## Create Azure Container Instance for SFTP
> User the following link to create a Azure Container Instance(ACI for SFTP)
> 
https://docs.microsoft.com/en-us/samples/azure-samples/sftp-creation-template/sftp-on-azure


> Kusto Queries used for Application Insights

```
search "ReceiveMessageFromServieBus"
| summarize count() by bin(timestamp, 1h)
| order by timestamp desc    

```
```
customEvents
| where isnotnull(customDimensions.ProcessName)
//| where customDimensions.ProcessName == 'ReceiveMessageFromServieBus'  
| summarize count() by bin(timestamp, 1m),  Key = tostring(customDimensions.ProcessName) 
| order by timestamp desc
| render columnchart
``` 
## Service Bus Pricing

![image](https://user-images.githubusercontent.com/15838780/153060922-c0052b81-c571-410e-b587-8aa83b633223.png)

  
  
## Products

|products|links|Comments|
|:----|:----|:----|
|Azure Getting Started |https://azure.microsoft.com/en-us/free/| Create free account + $200 in Credit|
|Sample Data Sets|https://www.kaggle.com/datasets| Useful site for pulling sample payload|
|Azure Storage Explorer|https://azure.microsoft.com/en-us/features/storage-explorer/#features|useful view and query data in azure table storage|
|Postman|https://www.postman.com/downloads/|Postman supports the Web or Desktop Version|
|VsCode| https://visualstudio.microsoft.com/downloads/ |  Required extensions. Azure Functions, Azure Account
|VS Studio Community Edition |https://visualstudio.microsoft.com/downloads/| Recommended. Nice intergration with Azure. software is free.

  ## Configuration-driven development
 
 "Configuration-driven development," refers to an approach in software development where the behavior and functionality of an application are primarily controlled through configuration files, rather than writing code. It focuses on separating application logic from configuration parameters, allowing developers to easily modify the behavior of the software without the need for extensive code changes.  [Xenhey.BPM.Core.Net6](https://www.nuget.org/packages/Xenhey.BPM.Core.Net6) offers a orchrestration pipeline using configuration to drive the execution of business logic, providing a tailored solution for each Line Of Business(LOB). The following are some benefits. 

 1. Flexibility: By using configuration files, developers can easily tweak and adjust the application's behavior without modifying the underlying code. It allows for quick customization and adaptation to different scenarios or client requirements.

2. Maintenance: Separating configuration from code simplifies maintenance processes. Updates and modifications can be made by adjusting the configuration files, reducing the risk of introducing bugs or breaking existing functionality. It also facilitates version control and collaboration, as changes to configuration can be tracked separately from code changes.

3. Scalability: Configuration-driven development promotes scalability by enabling the application to handle different environments, configurations, or user preferences. It allows for seamless deployment across multiple instances or environments with minimal code changes.

4. Testing and Validation: Configuration-driven development enhances testing and validation processes. Since configuration changes are isolated from the codebase, it becomes easier to verify the impact of different configurations on the application's behavior. It also facilitates A/B testing or experimentation by quickly switching between different configurations.

5. Domain-Specific Customization: Configuration-driven development enables domain-specific customization by providing options and settings tailored to specific use cases. This empowers non-technical users or administrators to configure the application according to their specific requirements without the need for coding expertise

  
  
  ## Contact
  
For questions related to this project, can be reached via email :- support@xenhey.com


﻿
