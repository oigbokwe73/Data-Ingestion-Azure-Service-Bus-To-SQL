param apimServiceName string
param apiName string
param productName string

resource apimService 'Microsoft.ApiManagement/service@2021-08-01' existing = {
  name: apimServiceName
}

resource api 'Microsoft.ApiManagement/service/apis@2021-08-01' existing = {
  name: '${apimServiceName}/${apiName}'
  scope: apimService
}

resource product 'Microsoft.ApiManagement/service/products@2021-08-01' existing = {
  name: '${apimServiceName}/${productName}'
  scope: apimService
}

resource apiToProduct 'Microsoft.ApiManagement/service/products/apis@2021-08-01' = {
  name: '${product.name}/${api.name}'
  scope: product
}
az deployment group create \
  --resource-group <YourResourceGroup> \
  --template-file add-api-to-product.bicep \
  --parameters apimServiceName='<APIM-Service-Name>' apiName='<API-Name>' productName='<Product-Name>'
