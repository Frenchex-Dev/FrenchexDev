using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine.Add;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType.Add;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Destroy;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Halt;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Init;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Name;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Ssh;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.SshConfig;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Status;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Up;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Cli.IntegrationLib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Cli.Integration.DependencyInjection;

public class ServicesConfiguration : IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        return StaticConfigureServices(serviceCollection);
    }

    /// <summary>
    ///     Configure services object against integration classes.
    ///     Integration classes are meant to be used only once during execution of CLI.
    ///     Marking them as Singleton will save their unique instance into the DI.
    ///     While we only need them once.
    ///     So we mark them as Transient so that created instances will not be managed
    ///     by DI.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection StaticConfigureServices(IServiceCollection services)
    {
        return new ServicesConfigurationServices().ConfigureServices(services,
            () =>
            {
                services
                    .AddTransient<IIntegration, Domain.Integration>();

                services
                    .AddTransient<IVosCommandIntegration, DefineCommandIntegration>()
                    .AddTransient<IDefineCommandIntegration, DefineCommandIntegration>()
                    .AddTransient<IDefineMachineCommandIntegration, DefineMachineCommandIntegration>()
                    .AddTransient<IDefineSubCommandIntegration, DefineMachineCommandIntegration>()
                    .AddTransient<IDefineMachineSubCommandIntegration, DefineMachineAddCommandIntegration>()
                    .AddTransient<IDefineSubCommandIntegration, DefineMachineTypeCommandIntegration>()
                    .AddTransient<IDefineMachineTypeSubCommandIntegration, DefineMachineTypeAddCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, DestroyCommandIntegration>()
                    .AddTransient<IDestroyCommandIntegration, DestroyCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, HaltCommandIntegration>()
                    .AddTransient<IHaltCommandIntegration, HaltCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, InitCommandIntegration>()
                    .AddTransient<IInitCommandIntegration, InitCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, SshCommandIntegration>()
                    .AddTransient<ISshCommandIntegration, SshCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, SshConfigCommandIntegration>()
                    .AddTransient<ISshConfigCommandIntegration, SshConfigCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, UpCommandIntegration>()
                    .AddTransient<IUpCommandIntegration, UpCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, StatusCommandIntegration>()
                    .AddTransient<IStatusCommandIntegration, StatusCommandIntegration>()
                    .AddTransient<IVosCommandIntegration, NameCommandIntegration>()
                    .AddTransient<INameCommandIntegration, NameCommandIntegration>()
                    ;

                services
                    .AddScoped<IBoxNameArgumentBuilder, BoxNameArgumentBuilder>()
                    .AddScoped<IInstancesArgumentBuilder, InstancesArgumentBuilder>()
                    .AddScoped<IMachineTypeNameArgumentBuilder, MachineTypeNameArgumentBuilder>()
                    .AddScoped<INameArgumentBuilder, NameArgumentBuilder>()
                    .AddScoped<INamesArgumentBuilder, NamesArgumentBuilder>()
                    .AddScoped<IOsVersionArgumentBuilder, OsVersionArgumentBuilder>()
                    .AddScoped<IOsTypeArgumentBuilder, OsTypeArgumentBuilder>()
                    .AddScoped<IParallelOptionBuilder, ParallelOptionBuilder>()
                    .AddScoped<IRamMbArgumentBuilder, RamMbArgumentBuilder>()
                    .AddScoped<IVirtualCpusArgumentBuilder, VirtualCpusArgumentBuilder>()
                    ;

                services
                    .AddScoped<IColorOptionBuilder, ColorOptionBuilder>()
                    .AddScoped<IEnabled3dOptionBuilder, Enabled3dOptionBuilder>()
                    .AddScoped<IEnabledOptionBuilder, EnabledOptionBuilder>()
                    .AddScoped<IForceOptionBuilder, ForceOptionBuilder>()
                    .AddScoped<IGracefulOptionBuilder, GracefulOptionBuilder>()
                    .AddScoped<IHostOptionBuilder, HostOptionBuilder>()
                    .AddScoped<ICommandsOptionBuilder, CommandsOptionBuilder>()
                    .AddScoped<IExtraSshArgsOptionBuilder, ExtraSshArgsOptionBuilder>()
                    .AddScoped<IParallelWaitOptionBuilder, ParallelWaitOptionBuilder>()
                    .AddScoped<IParallelWorkersOptionBuilder, ParallelWorkersOptionBuilder>()
                    .AddScoped<IIpv4PatternOptionBuilder, Ipv4PatternOptionBuilder>()
                    .AddScoped<IIpv4StartOptionBuilder, Ipv4StartOptionBuilder>()
                    .AddScoped<IVagrantBinPathOptionBuilder, VagrantBinPathOptionBuilder>()
                    .AddScoped<INamesOptionBuilder, NamesOptionBuilder>()
                    .AddScoped<INamingPatternOptionBuilder, NamingPatternOptionBuilder>()
                    .AddScoped<INetworkBridgeOptionBuilder, NetworkBridgeOptionBuilder>()
                    .AddScoped<IPlainTextOptionBuilder, PlainTextOptionBuilder>()
                    .AddScoped<IPrimaryOptionBuilder, PrimaryOptionBuilder>()
                    .AddScoped<IRamMbOptionBuilder, RamMbOptionBuilder>()
                    .AddScoped<ITimeoutMsOptionBuilder, TimeoutMsOptionBuilder>()
                    .AddScoped<IVirtualCpusOptionBuilder, VirtualCpusOptionBuilder>()
                    .AddScoped<IVirtualRamMbOptionBuilder, VirtualRamMbOptionBuilder>()
                    .AddScoped<IWorkingDirectoryOptionBuilder, WorkingDirectoryOptionBuilder>()
                    .AddScoped<IZeroesOptionBuilder, ZeroesOptionBuilder>()
                    .AddScoped<IParallelOptionBuilder, ParallelOptionBuilder>()
                    .AddScoped<IParallelWaitOptionBuilder, ParallelWaitOptionBuilder>()
                    .AddScoped<IParallelWorkersOptionBuilder, ParallelWorkersOptionBuilder>()
                    .AddScoped<IVagrantBinPathOptionBuilder, VagrantBinPathOptionBuilder>()
                    ;
            },
            () =>
            {
                Lib.DependencyInjection.ServicesConfiguration.StaticConfigureServices(services);
            });
    }
}