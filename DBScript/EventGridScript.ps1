$subscriptions = ""
$resourceGroups = "training20251008"
$storageAccounts = "training20251008"
$functionAppName = "training20251008"
$function = "Filedroptrigger"
$function1 = "FileParser"
$containerName = "processed"
$containerName1 = "pickup"
az eventgrid event-subscription create `
  --name blob-monitor-processed `
  --source-resource-id "/subscriptions/$subscriptions/resourceGroups/$resourceGroups/providers/Microsoft.Storage/storageAccounts/$storageAccounts" `
  --included-event-types Microsoft.Storage.BlobCreated  `
  --endpoint-type azurefunction `
  --endpoint "/subscriptions/$subscriptions/resourceGroups/$resourceGroups/providers/Microsoft.Web/sites/$functionAppName/functions/$function" `
  --subject-begins-with "/blobServices/default/containers/$containerName/"  `
  --subject-ends-with ".csv"  `
  --max-delivery-attempts 1  `


  az eventgrid event-subscription create `
  --name stp `
  --source-resource-id "/subscriptions/$subscriptions/resourceGroups/$resourceGroups/providers/Microsoft.Storage/storageAccounts/$storageAccounts" `
  --included-event-types Microsoft.Storage.BlobCreated  `
  --endpoint-type azurefunction `
  --endpoint "/subscriptions/$subscriptions/resourceGroups/$resourceGroups/providers/Microsoft.Web/sites/$functionAppName/functions/$function1" `
  --subject-begins-with "/blobServices/default/containers/$containerName1/"  `
  --subject-ends-with ".csv" --max-delivery-attempts 1
  
