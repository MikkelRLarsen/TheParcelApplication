FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

RUN apt-get update && apt-get install -y \
    libgssapi-krb5-2 \
    && rm -rf /var/lib/apt/lists/*
	
WORKDIR /app
EXPOSE 8002
ENV ASPNETCORE_URLS=http://+:8003

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Shared
COPY Shared/Shared.csproj Shared/Shared/

# Props + projects
COPY TerminalService/Directory.Packages.props TerminalService/

COPY TerminalService/TerminalService.Api/TerminalService.Api.csproj TerminalService/TerminalService.Api/
COPY TerminalService/TerminalService.Facade/TerminalService.Facade.csproj TerminalService/TerminalService.Facade/
COPY TerminalService/TerminalService.Domain/TerminalService.Domain.csproj TerminalService/TerminalService.Domain/
COPY TerminalService/TerminalService.UseCase/TerminalService.UseCase.csproj TerminalService/TerminalService.UseCase/
COPY TerminalService/TerminalService.Infrastructure/TerminalService.Infrastructure.csproj TerminalService/TerminalService.Infrastructure/
COPY TerminalService/TerminalService.InversionOfControl/TerminalService.InversionOfControl.csproj TerminalService/TerminalService.InversionOfControl/

RUN dotnet restore TerminalService/TerminalService.Api/TerminalService.Api.csproj

# Copy rest
COPY . .

RUN dotnet build TerminalService/TerminalService.Api/TerminalService.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish TerminalService/TerminalService.Api/TerminalService.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TerminalService.Api.dll"]