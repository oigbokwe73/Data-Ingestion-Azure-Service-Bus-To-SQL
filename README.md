### Use Case: Central Database for College Contact Information Management

#### **Objective**:
To create a centralized database that stores and manages all contact information for a college, ensuring secure and seamless ingestion of data via APIs and SFTP, automated processing, and efficient storage in an Azure SQL Database.

---

### **Actors**:
1. **College Administrators**: Upload or update contact information via APIs or SFTP.
2. **Integration System**: Handles data ingestion, processing, and storage.
3. **End Users**: Faculty, staff, and students querying contact information.


### **Benefits**:
1. **Centralization**: Consolidates all contact information into a single source of truth.
2. **Flexibility**: Supports multiple data ingestion methods (API and SFTP).
3. **Automation**: Reduces manual effort with automated triggers and workflows.
4. **Scalability**: Easily scales to handle increasing volumes of contact data.
5. **Security**: Ensures secure access to APIs and SFTP endpoints using  API keys 
6. **Real-time Reporting**: Enables real-time updates and analysis of contact information.

---

### **Mermaid Diagram**:
```mermaid
graph TD
    A[College Administrators] -->|API Upload| B[Azure Function App]
    A -->|SFTP Upload| C[Azure Storage Account]
    C -->|File Upload Event| D[Azure Event Grid]
    B -->|Data Ingested| E[Azure Service Bus Queue]
    D --> E
    E -->|Message Trigger| F[Azure Function App]
    F -->|Data Transformation| G[Azure SQL Database]
    G -->|Query| H[End Users/Applications]
    G -->|Data Visualization| I[Power BI]
```

---

### **Example Scenario**:
1. An administrator uploads a CSV file containing new student contacts via SFTP.
2. Azure Storage triggers an Event Grid notification when the file is uploaded.
3. Event Grid sends a message to the Service Bus queue.
4. The Function App processes the file, validates the data, and inserts it into the SQL Database.
5. Faculty members access the updated contact list via a web portal via and api integrated with the Azure SQL Database.

This solution ensures a robust, scalable, and automated system for managing college contact information effectively.
#  Data Ingestion into Azure Service Bus To SQL


## Event-Driven Microservice Architecture Diagram

![image](https://user-images.githubusercontent.com/15838780/226928604-4340b682-0e13-44bc-b239-6b91a29f678a.png)


## Session Recorded 
**[Session Video - 04/2025](https://youtu.be/JTrQYz6uTYY)**


[Session Video - 02/2025](https://www.youtube.com/playlist?list=PL0VzuNmHIvGw_MlH-U8yxyjlKGWEmEQyn)
---
**[Session Video - 01/2025](https://www.youtube.com/playlist?list=PL0VzuNmHIvGw_MlH-U8yxyjlKGWEmEQyn)**



## Data Ingestion Services in Azure 


Here's a comparison table highlighting the key features, strengths, and use cases for Azure Data Factory (ADF), Azure Databricks, Azure Synapse Analytics and Custom Data Ingestion Service

| **Feature**                            | **Azure Data Factory (ADF)**                           | **Azure Databricks**                                 | **Azure Synapse Analytics**                         |  **Custom Data Ingestion Service**                         |
|----------------------------------------|--------------------------------------------------------|------------------------------------------------------|----------------------------------------------------|----------------------------------------------------|
| **Purpose**                            | Data integration, ETL, and data orchestration          | Big data analytics, data engineering, and machine learning | Analytics, data warehousing, and big data processing |Data integration, ETL, and data orchestration |
| **Key Components**                     | Pipelines, Dataflows, Linked Services, Datasets        | Workspaces, Notebooks, Clusters, Jobs               | Dedicated SQL Pool, Serverless SQL Pool, Spark Pool, Data Integration |Dedicated SQL Pool, Serverless SQL Workflow, DataFlow. DataSets Linkservice :- api |
| **Data Integration**                   | Extensive connectors for various data sources          | Built-in integration with many data sources via notebooks | Integrated data ingestion and transformation       |Connectors to Azure Table Storage, Azure SQL |
| **Data Processing**                    | ETL/ELT processing using dataflows and pipelines       | Advanced data processing and analytics with Apache Spark | Unified analytics, SQL-based data processing, Spark, and pipelines |ETL/ELT processing using Orchestration  WorkFlow(JSON) sand pipelines |
| **Programming Languages**              | JSON for pipeline definitions, Dataflow expressions    | Scala, Python, R, SQL                               | T-SQL, Python, Scala, .NET                          |T-SQL,  .NET                          |
| **Scalability**                        | Automatically scalable                                  | Highly scalable with auto-scaling clusters           | Scalable from small to very large workloads         |Scalable from small to very large workloads |         
| **Compute Management**                 | Managed compute for data movement and transformation   | Customizable and managed Spark clusters              | Managed pools for SQL and Spark, auto-scaling       | Managed pools for  Azure functions and SQL, auto-scaling       |
| **Integration with Azure Services**    | Deep integration with Azure services like Azure SQL, Blob Storage | Strong integration with Azure storage, SQL, and AI services | Comprehensive integration with Azure ecosystem     |Deep integration with Azure services like Azure SQL, Blob Storage |
| **Data Movement**                      | Copy data activity for moving data across sources      | Supports data movement through Spark jobs            | Integrated data movement and transformation         | Copy data, move,slice and transform data across azure resources      | 
| **Orchestration**                      | Advanced scheduling, event-based triggers, and monitoring | Workflow management via jobs and notebooks           | Unified data and pipeline orchestration             | event-based triggers, and monitoring, Workflow management             |
| **Machine Learning**                   | Limited ML capabilities                                | Advanced ML with integrated MLflow and Spark MLlib   | Integrated ML capabilities with Synapse Studio      |Integrated ML capabilities with c# .NET|
| **User Interface**                     | GUI for pipeline design and monitoring                 | Notebooks for interactive development and visualization | Unified web-based interface for SQL, Spark, and pipelines | Web-based interface for SQL|
| **Security**                           | Built-in security features, VNET support, managed identity | Secure workspace, role-based access control (RBAC)  | Comprehensive security features, RBAC, encryption   | Built-in security features, VNET support, managed identity, RBAC |
| **Use Cases**                          | ETL/ELT processes, data migration, data integration    | Data engineering, big data analytics, machine learning workflows | Advanced analytics, data warehousing, big data processing, and data integration | ETL/ELT processes, data migration, data integration    |
| **Cost Structure**                     | Pay-as-you-go based on pipeline runs, data movement    | Pay-as-you-go based on compute and storage usage     | Pay-as-you-go for different pools, storage, and compute | Pay-as-you-go for different dedicated pools, storage, and compute |

## ADF Ingestion Sequence Diagram

![image](https://github.com/user-attachments/assets/da5933f8-e73a-454b-aebf-26161436abbf)

## Azure Data Bricks Ingestion Sequence Diagram

![image](https://github.com/user-attachments/assets/25952409-c26b-4856-9fb5-8cfd65e2ccea)


## Azure Synapse Analytics Ingestion Sequence Diagram

![image](https://github.com/user-attachments/assets/dc121b63-0e58-49ff-ba89-8807e0eb8dfd)












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
|ApiStore| [Remote Configuration Store]  | Connect to your remote config store
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
|[FA7BDA37345D4F4881A7473ACDF06B4A.json](https://www.xenhey.com/api/store/FA7BDA37345D4F4881A7473ACDF06B4A)| **Upload File** Parse CSV file --> Write Batched Files To Storage|
|[35C8400673BD4566AF97227BBC7A2754.json](https://www.xenhey.com/api/store/35C8400673BD4566AF97227BBC7A2754)| **File Parser** Parse CSV file --> File received from SFTP will use this process to parse files|
|[269CA9B3A0B542E3A5BB713005D591F7.json](https://www.xenhey.com/api/store/269CA9B3A0B542E3A5BB713005D591F7)| **Service Bus Trigger for SQL DB** | Receive JSON payload and insert into SQL DB|
|[00766FE7DC3E469CB8E3416B9BC6A26C.json](https://www.xenhey.com/api/store/00766FE7DC3E469CB8E3416B9BC6A26C)| **Service Bus Trigger for No SQL DB** | Receive JSON payload and insert into NO SQL DB|
|[2484F9382E974133A216F8E39BF4C389.json](https://www.xenhey.com/api/store/2484F9382E974133A216F8E39BF4C389)| **Blob Trigger** Send parsed/sharded file  to Send to Service Bus|
|[C1D791EBB8BF4491A61E3659298F46E8.json](https://www.xenhey.com/api/store/C1D791EBB8BF4491A61E3659298F46E8)| **Search Resullt from NO SQLDB** |
|[FC8AFFD1677A443D9D2A962A79246372.json](https://www.xenhey.com/api/store/FC8AFFD1677A443D9D2A962A79246372)| **Search SQL DB. Return resultset** |
|[C51F7629130B448AB4430D1260360C1E.json](https://www.xenhey.com/api/store/C51F7629130B448AB4430D1260360C1E)| **Copy File from SFTP into the pickup folder** |
|[68AA07F5193441878BFCD5CB372B25FB.json](https://www.xenhey.com/api/store/68AA07F5193441878BFCD5CB372B25FB)| **Create a new Record in NoSQL Database** |
|[31D9DA704F294BFBB9923CDFB7F0AEE6.json](https://www.xenhey.com/api/store/31D9DA704F294BFBB9923CDFB7F0AEE6)| Encode Payload Request |
|[9FDDE695D3534F91A3859825BC576857.json](https://www.xenhey.com/api/store/9FDDE695D3534F91A3859825BC576857)| Get reports from DB  |


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
|request|Create a Topic|
|nosqlmessage|Create a Subscription|
|sqlmessage|Create a Subscription|

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
  
  
## Products

|products|links|Comments|
|:----|:----|:----|
|Azure Getting Started |https://azure.microsoft.com/en-us/free/| Create free account + $200 in Credit|
|Sample Data Sets|https://www.kaggle.com/datasets| Useful site for pulling sample payload|
|Azure Storage Explorer|https://azure.microsoft.com/en-us/features/storage-explorer/#features|useful view and query data in azure table storage|
|Postman|https://www.postman.com/downloads/|Postman supports the Web or Desktop Version|
|VsCode| https://visualstudio.microsoft.com/downloads/ |  Required extensions. Azure Functions, Azure Account
|VS Studio Community Edition |https://visualstudio.microsoft.com/downloads/| Recommended. Nice intergration with Azure. software is free.
|Liquid Template|https://liquidjs.com/tutorials/intro-to-liquid.html|

  ## Configuration-driven development
 
 "Configuration-driven development," refers to an approach in software development where the behavior and functionality of an application are primarily controlled through configuration files, rather than writing code. It focuses on separating application logic from configuration parameters, allowing developers to easily modify the behavior of the software without the need for extensive code changes.  [Xenhey.BPM.Core.Net8](https://www.nuget.org/packages/Xenhey.BPM.Core.Net8) offers a orchrestration pipeline using configuration to drive the execution of business logic, providing a tailored solution for each Line Of Business(LOB). The following are some benefits. 

 1. Flexibility: By using configuration files, developers can easily tweak and adjust the application's behavior without modifying the underlying code. It allows for quick customization and adaptation to different scenarios or client requirements.

2. Maintenance: Separating configuration from code simplifies maintenance processes. Updates and modifications can be made by adjusting the configuration files, reducing the risk of introducing bugs or breaking existing functionality. It also facilitates version control and collaboration, as changes to configuration can be tracked separately from code changes.

3. Scalability: Configuration-driven development promotes scalability by enabling the application to handle different environments, configurations, or user preferences. It allows for seamless deployment across multiple instances or environments with minimal code changes.

4. Testing and Validation: Configuration-driven development enhances testing and validation processes. Since configuration changes are isolated from the codebase, it becomes easier to verify the impact of different configurations on the application's behavior. It also facilitates A/B testing or experimentation by quickly switching between different configurations.

5. Domain-Specific Customization: Configuration-driven development enables domain-specific customization by providing options and settings tailored to specific use cases. This empowers non-technical users or administrators to configure the application according to their specific requirements without the need for coding expertise



  ## Contact
  
For questions related to this project, can be reached via email :- support@xenhey.com


﻿
