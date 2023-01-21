#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine.Add;

public class DefineMachineAddCommandIntegration : ABaseCommandIntegration, IDefineMachineAddCommandIntegration
{
    private readonly IDefineMachineAddCommand _command;
    private readonly IEnabledOptionBuilder _enabledOptionBuilder;
    private readonly IInstancesArgumentBuilder _instancesArgumentBuilder;
    private readonly IIpv4PatternOptionBuilder _ipv4PatternOptionBuilder;
    private readonly IIpv4StartOptionBuilder _ipv4StartOptionBuilder;
    private readonly IMachineTypeNameArgumentBuilder _machineTypeNameArgumentBuilder;
    private readonly INameArgumentBuilder _nameArgumentBuilder;
    private readonly INamingPatternOptionBuilder _namingPatternOptionBuilder;
    private readonly INetworkBridgeOptionBuilder _networkBridgeOptionBuilder;
    private readonly IPrimaryOptionBuilder _primaryOptionBuilder;
    private readonly IRamMbOptionBuilder _ramMbOptionBuilder;
    private readonly IDefineMachineAddCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly IVirtualCpusOptionBuilder _virtualCpusOptionBuilder;

    public DefineMachineAddCommandIntegration(
        IDefineMachineAddCommand command,
        IDefineMachineAddCommandRequestBuilderFactory responseBuilderFactory,
        INameArgumentBuilder nameArgumentBuilder,
        IMachineTypeNameArgumentBuilder machineTypeNameArgumentBuilder,
        IInstancesArgumentBuilder instancesArgumentBuilder,
        INamingPatternOptionBuilder namingPatternOptionBuilder,
        IPrimaryOptionBuilder primaryOptionBuilder,
        IEnabledOptionBuilder enabledOptionBuilder,
        IVirtualCpusOptionBuilder virtualCpusOptionBuilder,
        IRamMbOptionBuilder ramMbOptionBuilder,
        IIpv4PatternOptionBuilder ipv4PatternOptionBuilder,
        IIpv4StartOptionBuilder ipv4StartOptionBuilder,
        INetworkBridgeOptionBuilder networkBridgeOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = responseBuilderFactory;
        _nameArgumentBuilder = nameArgumentBuilder;
        _machineTypeNameArgumentBuilder = machineTypeNameArgumentBuilder;
        _instancesArgumentBuilder = instancesArgumentBuilder;
        _namingPatternOptionBuilder = namingPatternOptionBuilder;
        _primaryOptionBuilder = primaryOptionBuilder;
        _enabledOptionBuilder = enabledOptionBuilder;
        _virtualCpusOptionBuilder = virtualCpusOptionBuilder;
        _ramMbOptionBuilder = ramMbOptionBuilder;
        _ipv4PatternOptionBuilder = ipv4PatternOptionBuilder;
        _ipv4StartOptionBuilder = ipv4StartOptionBuilder;
        _networkBridgeOptionBuilder = networkBridgeOptionBuilder;
    }

    public void Integrate(Command rootCommand)
    {
        var nameArg = _nameArgumentBuilder.Build();
        var typeArg = _machineTypeNameArgumentBuilder.Build();
        var instancesArg = _instancesArgumentBuilder.Build();
        var namingPatternOpt = _namingPatternOptionBuilder.Build();

        var isPrimaryOpt = _primaryOptionBuilder.Build();
        var isEnabledOpt = _enabledOptionBuilder.Build();
        var vCpusOpt = _virtualCpusOptionBuilder.Build();
        var ramMbOpt = _ramMbOptionBuilder.Build();
        var ipv4PatternOpt = _ipv4PatternOptionBuilder.Build();
        var ipv4StartOpt = _ipv4StartOptionBuilder.Build();
        var networkBridgeOpt = _networkBridgeOptionBuilder.Build();
        var timeoutStrOpt = TimeoutStrOptionBuilder?.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder?.Build();
        var vagrantBinPath = VagrantBinPathOptionBuilder?.Build();

        var command = new Command("add", "Add a new Machine")
        {
            nameArg,
            typeArg,
            instancesArg,
            namingPatternOpt,
            isPrimaryOpt,
            isEnabledOpt,
            vCpusOpt,
            ramMbOpt,
            ipv4PatternOpt,
            ipv4StartOpt,
            networkBridgeOpt,
            timeoutStrOpt!,
            workingDirOpt!,
            vagrantBinPath!
        };

        var binder = new DefineMachineAddCommandIntegrationPayloadBinder(
            nameArg,
            typeArg,
            instancesArg,
            namingPatternOpt,
            isPrimaryOpt,
            isEnabledOpt,
            vCpusOpt,
            ramMbOpt,
            ipv4PatternOpt,
            ipv4StartOpt,
            networkBridgeOpt,
            timeoutStrOpt!,
            workingDirOpt!,
            vagrantBinPath!
        );

        command.SetHandler(async context =>
        {
            IDefineMachineAddCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();

            DefineMachineAddCommandIntegrationPayload? payload = binder.GetBoundValue(context);

            BuildBase(requestBuilder, payload);

            IDefineMachineAddCommandRequest? request = requestBuilder
                .UsingDefinition(new MachineDefinitionDeclaration
                {
                    Name = payload.Name,
                    VirtualCpus = payload.VCpus,
                    RamInMb = payload.RamInMb,
                    MachineTypeName = payload.Type,
                    Instances = payload.Instances,
                    IsEnabled = payload.Enabled,
                    Ipv4Pattern = payload.IPv4Pattern,
                    Ipv4Start = payload.IPv4Start,
                    IsPrimary = payload.IsPrimary,
                    NamingPattern = payload.NamingPattern,
                    NetworkBridge = payload.NetworkBridge
                })
                .Build();

            await _command.ExecuteAsync(request);

            context.ExitCode = 0;
        });

        rootCommand.AddCommand(command);
    }
}