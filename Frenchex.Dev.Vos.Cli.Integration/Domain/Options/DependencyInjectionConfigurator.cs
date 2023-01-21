#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public static class DependencyInjectionConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
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
            .AddScoped<IMachineTypeOptionBuilder, MachineTypeOptionBuilder>()
            .AddScoped<INamesOptionBuilder, NamesOptionBuilder>()
            .AddScoped<INamingPatternOptionBuilder, NamingPatternOptionBuilder>()
            .AddScoped<INetworkBridgeOptionBuilder, NetworkBridgeOptionBuilder>()
            .AddScoped<IOsVersionOptionBuilder, OsVersionOptionBuilder>()
            .AddScoped<IPlainTextOptionBuilder, PlainTextOptionBuilder>()
            .AddScoped<IPrimaryOptionBuilder, PrimaryOptionBuilder>()
            .AddScoped<IPrivilegedOptionBuilder, PrivilegedOptionBuilder>()
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
    }
}