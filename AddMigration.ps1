param (
    [string]$service,
    [string]$m,
    [string]$c = "EFAppContext"
)

if (-not $service) {
    Write-Error "Du skal angive -service (fx ParcelService)"
    exit
}

if (-not $m) {
    Write-Error "Du skal angive -m (migration name)"
    exit
}

$projectPath = ".\src\$service\$service.Infrastructure\$service.Infrastructure.csproj"
$startupPath = ".\src\$service\$service.Api\$service.Api.csproj"

Write-Host "Runs command:"
Write-Host "dotnet ef migrations add $m --context $c --project $projectPath --startup-project $startupPath"

dotnet ef migrations add $m `
    --context $c `
    --project $projectPath `
    --startup-project $startupPath