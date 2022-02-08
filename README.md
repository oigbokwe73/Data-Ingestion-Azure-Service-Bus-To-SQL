# Azure Service Bus To SQL


## Architecture Diagram

![image](https://user-images.githubusercontent.com/15838780/152911729-e86ae271-8fc0-4ef5-b2cf-0198dc14ae5b.png)


## Appplication Setting 

|Key|Value | Comment|
|:----|:----|:----|
|AzureWebJobsStorage|[CONNECTION STRING]|RECOMMENDATION :  store in AzureKey Vault.|
|ConfigurationPath| [CONFIGURATION FOLDER PATH] |Folder is optional
|ApiKeyName|[API KEY NAME]|Will be passed in the header  :  the file name of the config.
|AppName| [APPLICATION NAME]| This is the name of the Function App. Used in log analytics|
|StorageAcctName|[STORAGE ACCOUNT NAME]|Example  "AzureWebJobsStorage"|
|EventHubConnectionAppSetting|[EVENT HUB CONNECTION STRING]|Example  "EventHubConnectionAppSetting"|


> **Note:**  Look at the configuration file in the **Config** Folder and created a Table to record information.

## Function App  Configuration 

> **Note:** The **Configuration** is located in the  FunctionApp  in a **Config** Folder.

|FileName|Description|
|:----|:----|
|43EFE991E8614CFB9EDECF1B0FDED37A.json| **Upload File** Parse CSV file --> Write Batched Files To Storage|
|43EFE991E8614CFB9EDECF1B0FDED37D.json| **Blob Trigger** Read Parsed CSV files --> Converts To JSON --> Sends To Event Hub|
|43EFE991E8614CFB9EDECF1B0FDED37B.json| **Event Hub Trigger** Read JSON Array from Event Hub --> Writes to a NoSQL DB|
|43EFE991E8614CFB9EDECF1B0FDED37C.json| **Search** NoSQL DB for ingested records|

## Upload Configuration to Storage
Go to created storage Account.. Click On "Blob Service" 
![image](https://user-images.githubusercontent.com/15838780/147958072-4a6058d2-d320-44a0-9d11-58449d527cd3.png)

Click on **"Container"**
![image](https://user-images.githubusercontent.com/15838780/147958201-71df0f21-e4e8-46c0-93be-728f1dbc2a43.png)
![image](https://user-images.githubusercontent.com/15838780/147963170-1a2f2a64-7ba2-44ce-9f5d-30d490529711.png)


## Upload CSV File

|Key|Value|Comments|
|:----|:----|:----|
|ReadCsvAsStream|Yes| Required to parse the csv file while uploading|
|messageformat|application/json OR application/xml| required|
|FolderName||OPTIONAL:This is required for additonal XSL transformation |
|FileName||OPTIONAL:This is required for additonal XSL transformation |
|TableName|<AZURE TABLE NAME>| REQUIRED Create table add records|
|StorageAccount|<STORAGE ACCOUNT KEY>| Name of the  storage account key in AppSettings.|
|StorageAccount|<STORAGE ACCOUNT KEY>| Name of the  storage account key in AppSettings.|



## Search Record

|Key|Value|Comments|
|:----|:----|:----|
|SimpleTableSearch|Yes| Indicates the method in the process to use the API|
|PartitionKey|<PROPERTY NAME >|OPTIONAL : Identity the  Field/Key in the JSON payload as a Partition Key|
|QueryField|<SEARCH PROPERTY NAME>|Provide the search property name to be used in the search
|DefaultResult| <CUSTOM MESSAGE> | OPTIONAL :  No  results return then a default message
|TableName|<AZURE TABLE NAME>| REQUIRED : Create a Table |
|Container|<CONTAINER NAME>|  REQUIRED : Create a container name eg "csvprocessed".|
  
  
  ## Products

|products|links|Comments|
|:----|:----|:----|
|Azure Getting Started |https://azure.microsoft.com/en-us/free/| Create free account + $200 in Credit|
|Sample Data Sets|https://www.kaggle.com/datasets| Useful site for pulling sample payload|
|Azure Storage Explorer|https://azure.microsoft.com/en-us/features/storage-explorer/#features|useful view and query data in azure table storage|
|Postman|https://www.postman.com/downloads/|Postman supports the Web or Desktop Version|
|VsCode| https://visualstudio.microsoft.com/downloads/ |  Required extensions. Azure Functions, Azure Account
|VS Studio Community Edition |https://visualstudio.microsoft.com/downloads/| Recommended. Nice intergration with Azure. software is free.

  
  
  ## Contact
  
For questions related to this project, can be reached via email :- support@xenhey.com
