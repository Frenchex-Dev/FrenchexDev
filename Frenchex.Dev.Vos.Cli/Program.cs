using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Frenchex.Dev.OnSteroid.Cli.Lib.Domain;
using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;
using Frenchex.Dev.Vos.Cli;
using Frenchex.Dev.Vos.Cli.Integration.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

await HostBasedProgramBuildAndRunAsyncWorkflow.BuildAndRunAsync<Host>(
    new ServiceCollection(),
    new ProgramBuilder(),
    new ServicesConfiguration(),
    new Context(
        "Configurations\\hostsettings.json",
        "Configurations\\appsettings.json",
        "FRENCHEXDEV_VOS",
        Directory.GetCurrentDirectory(),
        AppDomain.CurrentDomain.BaseDirectory
    )
);