FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
	
WORKDIR /app
EXPOSE 8004
ENV ASPNETCORE_URLS=http://+:8004

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY Shared/Shared.csproj Shared/Shared/

COPY AllocationService/Directory.Packages.props AllocationService/

COPY AllocationService/AllocationService.Api/AllocationService.Api.csproj AllocationService/AllocationService.Api/
COPY AllocationService/AllocationService.Facade/AllocationService.Facade.csproj AllocationService/AllocationService.Facade/
COPY AllocationService/AllocationService.Domain/AllocationService.Domain.csproj AllocationService/AllocationService.Domain/
COPY AllocationService/AllocationService.UseCase/AllocationService.UseCase.csproj AllocationService/AllocationService.UseCase/
COPY AllocationService/AllocationService.Infrastructure/AllocationService.Infrastructure.csproj AllocationService/AllocationService.Infrastructure/
COPY AllocationService/AllocationService.InversionOfControl/AllocationService.InversionOfControl.csproj AllocationService/AllocationService.InversionOfControl/

RUN dotnet restore AllocationService/AllocationService.Api/AllocationService.Api.csproj

COPY . .

RUN dotnet build AllocationService/AllocationService.Api/AllocationService.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish AllocationService/AllocationService.Api/AllocationService.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AllocationService.Api.dll"]