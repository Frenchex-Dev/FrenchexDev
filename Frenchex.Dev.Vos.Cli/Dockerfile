#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Frenchex.Dev.Vos.Cli/Frenchex.Dev.Vos.Cli.csproj", "Frenchex.Dev.Vos.Cli/"]
COPY ["Frenchex.Dev.OnSteroid.Cli.Lib/Frenchex.Dev.OnSteroid.Cli.Lib.csproj", "Frenchex.Dev.OnSteroid.Cli.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib/Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.System.CommandLine/Frenchex.Dev.Dotnet.Core.Dependencies.System.CommandLine.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.System.CommandLine/"]
COPY ["Frenchex.Dev.Dotnet.Core.Cli.Lib/Frenchex.Dev.Dotnet.Core.Cli.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Cli.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions/Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.csproj", "Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.DependencyInjection.Abstractions.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.DependencyInjection.Abstractions.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.DependencyInjection.Abstractions.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.Hosting.Abstractions.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.Hosting.Abstractions.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.Hosting.Abstractions.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.Logging.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.Logging.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.Logging.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.Configuration.Abstractions.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.Configuration.Abstractions.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.Configuration.Abstractions.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.Hosting.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.Hosting.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.Hosting.Lib/"]
COPY ["Frenchex.Dev.OnSteroid.Cli.Lib.Integration/Frenchex.Dev.OnSteroid.Cli.Lib.Integration.csproj", "Frenchex.Dev.OnSteroid.Cli.Lib.Integration/"]
COPY ["Frenchex.Dev.OnSteroid.Lib/Frenchex.Dev.OnSteroid.Lib.csproj", "Frenchex.Dev.OnSteroid.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.DependencyInjection.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.DependencyInjection.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.DependencyInjection.Lib/"]
COPY ["Frenchex.Dev.OnSteroid.Lib.Abstractions/Frenchex.Dev.OnSteroid.Lib.Abstractions.csproj", "Frenchex.Dev.OnSteroid.Lib.Abstractions/"]
COPY ["Frenchex.Dev.Vos.Cli.IntegrationLib/Frenchex.Dev.Vos.Cli.IntegrationLib.csproj", "Frenchex.Dev.Vos.Cli.IntegrationLib/"]
COPY ["Frenchex.Dev.Vos.Cli.Integration/Frenchex.Dev.Vos.Cli.Integration.csproj", "Frenchex.Dev.Vos.Cli.Integration/"]
COPY ["Frenchex.Dev.Vos.Lib/Frenchex.Dev.Vos.Lib.csproj", "Frenchex.Dev.Vos.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.NewtonSoft.Json/Frenchex.Dev.Dotnet.Core.Dependencies.NewtonSoft.Json.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.NewtonSoft.Json/"]
COPY ["Frenchex.Dev.Vagrant.Lib/Frenchex.Dev.Vagrant.Lib.csproj", "Frenchex.Dev.Vagrant.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.Configuration.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.Configuration.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.Configuration.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Wrapping.Lib/Frenchex.Dev.Dotnet.Core.Wrapping.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Wrapping.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Filesystem.Lib/Frenchex.Dev.Dotnet.Core.Filesystem.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Filesystem.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Process.Lib/Frenchex.Dev.Dotnet.Core.Process.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Process.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Dependencies.Logging.Abstractions.Lib/Frenchex.Dev.Dotnet.Core.Dependencies.Logging.Abstractions.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Dependencies.Logging.Abstractions.Lib/"]
COPY ["Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib/Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib.csproj", "Frenchex.Dev.Dotnet.Core.Tooling.TimeSpan.Lib/"]
COPY ["Frenchex.Dev.Vagrant.Lib.Abstractions/Frenchex.Dev.Vagrant.Lib.Abstractions.csproj", "Frenchex.Dev.Vagrant.Lib.Abstractions/"]
COPY ["Frenchex.Dev.Vos.Lib.Abstractions/Frenchex.Dev.Vos.Lib.Abstractions.csproj", "Frenchex.Dev.Vos.Lib.Abstractions/"]
RUN dotnet restore "Frenchex.Dev.Vos.Cli/Frenchex.Dev.Vos.Cli.csproj"
COPY . .
WORKDIR "/src/Frenchex.Dev.Vos.Cli"
RUN dotnet build "Frenchex.Dev.Vos.Cli.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Frenchex.Dev.Vos.Cli.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "vos.dll"]