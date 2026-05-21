FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

RUN apt-get update && apt-get install -y \
    libgssapi-krb5-2 \
    && rm -rf /var/lib/apt/lists/*
	
WORKDIR /app
EXPOSE 8002
ENV ASPNETCORE_URLS=http://+:8002

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY Shared/Shared.csproj Shared/Shared/

COPY RoutingService/Directory.Packages.props RoutingService/

COPY RoutingService/RoutingService.Api/RoutingService.Api.csproj RoutingService/RoutingService.Api/
COPY RoutingService/RoutingService.Facade/RoutingService.Facade.csproj RoutingService/RoutingService.Facade/
COPY RoutingService/RoutingService.Domain/RoutingService.Domain.csproj RoutingService/RoutingService.Domain/
COPY RoutingService/RoutingService.UseCase/RoutingService.UseCase.csproj RoutingService/RoutingService.UseCase/
COPY RoutingService/RoutingService.Infrastructure/RoutingService.Infrastructure.csproj RoutingService/RoutingService.Infrastructure/
COPY RoutingService/RoutingService.InversionOfControl/RoutingService.InversionOfControl.csproj RoutingService/RoutingService.InversionOfControl/

RUN dotnet restore RoutingService/RoutingService.Api/RoutingService.Api.csproj

COPY . .

RUN dotnet build RoutingService/RoutingService.Api/RoutingService.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish RoutingService/RoutingService.Api/RoutingService.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "RoutingService.Api.dll"]