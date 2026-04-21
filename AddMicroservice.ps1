param(
    [Parameter(Mandatory=$true)]
    [string]$ProjectName
)

$templateShortName = "clean-temp"

$installed = dotnet new list | Select-String $templateShortName
if (-not $installed) {
	dotnet new install ./TemplateFolder
}

dotnet new clean-temp -n $ProjectName -o src/$ProjectName

$projects = @(
	"Api",
	"Domain",
	"Infrastructure",
	"Facade",
	"UnitTest",
	"UseCase",
	"InversionOfControl"
	)

foreach ($project in $projects) {
	dotnet sln add src/$ProjectName/$ProjectName.$project/$ProjectName.$project.csproj
}

