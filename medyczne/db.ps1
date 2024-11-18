# Read appsettings.json
$appSettings = Get-Content -Raw -Path "./appsettings.json" | ConvertFrom-Json

# Extract the connection string
$connString = $appSettings.ConnectionStrings.APP_DB

# Run the scaffold command
dotnet ef dbcontext scaffold $connString Npgsql.EntityFrameworkCore.PostgreSQL  -o Models 
