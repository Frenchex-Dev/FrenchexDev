#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine.Add;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType.Add;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning.Map;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Destroy;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Halt;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Init;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Name;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Provision;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Ssh;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.SshConfig;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Status;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;

public static class DependencyInjectionConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        AddDefineCommands(services);
        AddDestroyCommand(services);
        AddHaltCommand(services);
        AddInitCommand(services);
        AddNameCommand(services);
        AddProvisionCommand(services);
        AddSshCommand(services);
        AddSshConfigCommand(services);
        AddStatusCommand(services);
        AddUpCommand(services);
    }

    private static void AddProvisionCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, ProvisionCommandIntegration>()
            .AddTransient<IProvisionCommandIntegration, ProvisionCommandIntegration>()
            ;
    }

    private static void AddDestroyCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, DestroyCommandIntegration>()
            .AddTransient<IDestroyCommandIntegration, DestroyCommandIntegration>()
            ;
    }

    private static void AddDefineCommands(IServiceCollection services)
    {
        services
            // Define
            .AddTransient<IVosCommandIntegration, DefineCommandIntegration>()
            .AddTransient<IDefineCommandIntegration, DefineCommandIntegration>()
            // Define Machine Type
            .AddTransient<IDefineSubCommandIntegration, DefineMachineTypeCommandIntegration>()
            .AddTransient<IDefineMachineTypeCommandIntegration, DefineMachineTypeCommandIntegration>()
            // Define Machine Type Add
            .AddTransient<IDefineMachineTypeSubCommandIntegration, DefineMachineTypeAddCommandIntegration>()
            .AddTransient<IDefineMachineTypeAddCommandIntegration, DefineMachineTypeAddCommandIntegration>()
            // Define Machine
            .AddScoped<IDefineSubCommandIntegration, DefineMachineCommandIntegration>()
            .AddScoped<IDefineMachineCommandIntegration, DefineMachineCommandIntegration>()
            // Define Machine Add
            .AddTransient<IDefineMachineSubCommandIntegration, DefineMachineAddCommandIntegration>()
            .AddTransient<IDefineMachineAddCommandIntegration, DefineMachineAddCommandIntegration>()
            // Define Provisioning
            .AddScoped<IDefineSubCommandIntegration, DefineProvisioningCommandIntegration>()
            .AddScoped<IDefineProvisioningCommandIntegration, DefineProvisioningCommandIntegration>()
            // Define Provisioning Map
            .AddTransient<IDefineProvisioningSubCommandIntegration, DefineProvisioningMapCommandIntegration>()
            .AddTransient<IDefineProvisioningMapCommandIntegration, DefineProvisioningMapCommandIntegration>()
            ;
    }

    private static void AddHaltCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, HaltCommandIntegration>()
            .AddTransient<IHaltCommandIntegration, HaltCommandIntegration>()
            ;
    }

    private static void AddInitCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, InitCommandIntegration>()
            .AddTransient<IInitCommandIntegration, InitCommandIntegration>()
            ;
    }

    private static void AddNameCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, NameCommandIntegration>()
            .AddTransient<INameCommandIntegration, NameCommandIntegration>()
            ;
    }

    private static void AddSshCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, SshCommandIntegration>()
            .AddTransient<ISshCommandIntegration, SshCommandIntegration>()
            ;
    }

    private static void AddSshConfigCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, SshConfigCommandIntegration>()
            .AddTransient<ISshConfigCommandIntegration, SshConfigCommandIntegration>()
            ;
    }

    private static void AddStatusCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, StatusCommandIntegration>()
            .AddTransient<IStatusCommandIntegration, StatusCommandIntegration>()
            ;
    }

    private static void AddUpCommand(IServiceCollection services)
    {
        services
            .AddTransient<IVosCommandIntegration, UpCommandIntegration>()
            .AddTransient<IUpCommandIntegration, UpCommandIntegration>()
            ;
    }
}