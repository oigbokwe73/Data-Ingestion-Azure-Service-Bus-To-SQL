$subscriptions = "4501a4d3-74c8-4703-9948-8c405a64daf0"
$resourceGroups = "training20250806"
$storageAccounts = "training20250806"
$functionAppName = "training20250806"
$function = "Filedroptrigger"
$containerName = "processed"
az eventgrid event-subscription create `
  --name blob-monitor-subscription `
  --source-resource-id "/subscriptions/$subscriptions/resourceGroups/$resourceGroups/providers/Microsoft.Storage/storageAccounts/$storageAccounts" `
  --included-event-types Microsoft.Storage.BlobCreated  `
  --endpoint-type azurefunction `
  --endpoint "/subscriptions/$subscriptions/resourceGroups/$resourceGroups/providers/Microsoft.Web/sites/$functionAppName/functions/$function" `
  --advanced-filter data.blobType StringContains BlockBlob `
  --advanced-filter subject StringBeginsWith "/blobServices/default/containers/$containerName/"