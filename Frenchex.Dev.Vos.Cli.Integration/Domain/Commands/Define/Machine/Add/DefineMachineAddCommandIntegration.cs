using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add;

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
        Argument<string> nameArg = _nameArgumentBuilder.Build();
        Argument<string> typeArg = _machineTypeNameArgumentBuilder.Build();
        Argument<int> instancesArg = _instancesArgumentBuilder.Build();
        Option<string> namingPatternOpt = _namingPatternOptionBuilder.Build();

        Option<bool> isPrimaryOpt = _primaryOptionBuilder.Build();
        Option<bool> isEnabledOpt = _enabledOptionBuilder.Build();
        Option<int> vCpusOpt = _virtualCpusOptionBuilder.Build();
        Option<int> ramMbOpt = _ramMbOptionBuilder.Build();
        Option<string> ipv4PatternOpt = _ipv4PatternOptionBuilder.Build();
        Option<int> ipv4StartOpt = _ipv4StartOptionBuilder.Build();
        Option<string> networkBridgeOpt = _networkBridgeOptionBuilder.Build();
        Option<string>? timeoutStrOpt = TimeoutStrOptionBuilder?.Build();
        Option<string>? workingDirOpt = WorkingDirectoryOptionBuilder?.Build();
        Option<string>? vagrantBinPath = VagrantBinPathOptionBuilder?.Build();

        var command = new Command("add", "Add a new Machine") {
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
            var requestBuilder = _requestBuilderFactory.Factory();

            var payload = binder.GetBoundValue(context);

            BuildBase(requestBuilder, payload);

            var request = requestBuilder
                .UsingDefinition(new MachineDefinitionDeclaration {
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