FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

RUN apt-get update && apt-get install -y \
    libgssapi-krb5-2 \
    && rm -rf /var/lib/apt/lists/*
	
WORKDIR /app
EXPOSE 8001
ENV ASPNETCORE_URLS=http://+:8001

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Shared først
COPY Shared/Shared.csproj Shared/Shared/

# Props + projekter
COPY ParcelService/Directory.Packages.props ParcelService/

COPY ParcelService/ParcelService.Api/ParcelService.Api.csproj ParcelService/ParcelService.Api/
COPY ParcelService/ParcelService.Facade/ParcelService.Facade.csproj ParcelService/ParcelService.Facade/
COPY ParcelService/ParcelService.Domain/ParcelService.Domain.csproj ParcelService/ParcelService.Domain/
COPY ParcelService/ParcelService.UseCase/ParcelService.UseCase.csproj ParcelService/ParcelService.UseCase/
COPY ParcelService/ParcelService.Infrastructure/ParcelService.Infrastructure.csproj ParcelService/ParcelService.Infrastructure/
COPY ParcelService/ParcelService.InversionOfControl/ParcelService.InversionOfControl.csproj ParcelService/ParcelService.InversionOfControl/

RUN dotnet restore ParcelService/ParcelService.Api/ParcelService.Api.csproj

# Resten af koden
COPY . .

RUN dotnet build ParcelService/ParcelService.Api/ParcelService.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish ParcelService/ParcelService.Api/ParcelService.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ParcelService.Api.dll"]