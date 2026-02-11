# Cloud Dental Office - Azure Deployment Configuration

parameters:
  - name: location
    type: string
    default: 'eastus'
  - name: environment
    type: string
    default: 'dev'
  - name: appServicePlanSku
    type: string
    default: 'P1v3'

resources:
  # App Service Plan
  - type: Microsoft.Web/serverfarms
    apiVersion: 2022-09-01
    name: asp-clouddental-${environment}
    location: ${location}
    sku:
      name: ${appServicePlanSku}
      tier: PremiumV3
      capacity: 1
    kind: linux
    properties:
      reserved: true

  # App Service (Blazor Server)
  - type: Microsoft.Web/sites
    apiVersion: 2022-09-01
    name: app-clouddental-${environment}
    location: ${location}
    dependsOn:
      - asp-clouddental-${environment}
    properties:
      serverFarmId: resourceId('Microsoft.Web/serverfarms', 'asp-clouddental-${environment}')
      siteConfig:
        linuxFxVersion: 'DOTNETCORE|8.0'
        alwaysOn: true
        http20Enabled: true
        minTlsVersion: '1.2'
        ftpsState: 'Disabled'
        appSettings:
          - name: ASPNETCORE_ENVIRONMENT
            value: ${environment}
          - name: WEBSITE_RUN_FROM_PACKAGE
            value: '1'
          - name: KeyVault__VaultUri
            value: https://kv-clouddental-${environment}.vault.azure.net/

  # SQL Server
  - type: Microsoft.Sql/servers
    apiVersion: 2022-05-01-preview
    name: sql-clouddental-${environment}
    location: ${location}
    properties:
      administratorLogin: clouddentaladmin
      administratorLoginPassword: ${sqlAdminPassword}
      version: '12.0'
      minimalTlsVersion: '1.2'
      publicNetworkAccess: Enabled

  # SQL Database
  - type: Microsoft.Sql/servers/databases
    apiVersion: 2022-05-01-preview
    name: sql-clouddental-${environment}/CloudDentalOffice
    location: ${location}
    dependsOn:
      - sql-clouddental-${environment}
    sku:
      name: S1
      tier: Standard
    properties:
      collation: SQL_Latin1_General_CP1_CI_AS
      maxSizeBytes: 268435456000
      catalogCollation: SQL_Latin1_General_CP1_CI_AS
      zoneRedundant: false

  # Storage Account
  - type: Microsoft.Storage/storageAccounts
    apiVersion: 2022-09-01
    name: stclouddental${environment}
    location: ${location}
    sku:
      name: Standard_LRS
    kind: StorageV2
    properties:
      supportsHttpsTrafficOnly: true
      minimumTlsVersion: TLS1_2
      
  # Key Vault
  - type: Microsoft.KeyVault/vaults
    apiVersion: 2022-07-01
    name: kv-clouddental-${environment}
    location: ${location}
    properties:
      sku:
        family: A
        name: standard
      tenantId: ${tenantId}
      enableRbacAuthorization: true
      enableSoftDelete: true
      softDeleteRetentionInDays: 90

  # Application Insights
  - type: Microsoft.Insights/components
    apiVersion: 2020-02-02
    name: appi-clouddental-${environment}
    location: ${location}
    kind: web
    properties:
      Application_Type: web
      RetentionInDays: 90
      publicNetworkAccessForIngestion: Enabled
      publicNetworkAccessForQuery: Enabled

outputs:
  appServiceUrl:
    type: string
    value: https://app-clouddental-${environment}.azurewebsites.net
  sqlServerFqdn:
    type: string
    value: sql-clouddental-${environment}.database.windows.net
