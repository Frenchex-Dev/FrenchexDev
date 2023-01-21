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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning.Map;

public class DefineProvisioningMapCommandIntegration : ABaseCommandIntegration, IDefineProvisioningMapCommandIntegration
{
    private readonly IDefineProvisioningMapCommand _command;
    private readonly IEnabledOptionBuilder _enabledOptionBuilder;
    private readonly IMachineTypeOptionBuilder _machineTypeOptionBuilder;
    private readonly INameArgumentBuilder _nameArgumentBuilder;
    private readonly IPrivilegedOptionBuilder _privilegedOptionBuilder;
    private readonly IProvisionNameArgumentBuilder _provisionNameArgumentBuilder;
    private readonly IDefineProvisioningMapCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly IVersionArgumentBuilder _versionArgumentBuilder;

    public DefineProvisioningMapCommandIntegration(
        IDefineProvisioningMapCommand command,
        IDefineProvisioningMapCommandRequestBuilderFactory requestBuilderFactory,
        INameArgumentBuilder nameArgumentBuilder,
        IProvisionNameArgumentBuilder provisionNameArgumentBuilder,
        IPrivilegedOptionBuilder privilegedOptionBuilder,
        IEnabledOptionBuilder enabledOptionBuilder,
        IMachineTypeOptionBuilder machineTypeOptionBuilder,
        IVersionArgumentBuilder versionArgumentBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _nameArgumentBuilder = nameArgumentBuilder;
        _provisionNameArgumentBuilder = provisionNameArgumentBuilder;
        _privilegedOptionBuilder = privilegedOptionBuilder;
        _enabledOptionBuilder = enabledOptionBuilder;
        _machineTypeOptionBuilder = machineTypeOptionBuilder;
        _versionArgumentBuilder = versionArgumentBuilder;
    }

    public void Integrate(Command rootCommand)
    {
        var nameArg = _nameArgumentBuilder.Build();
        var provisionNameArg = _provisionNameArgumentBuilder.Build();
        var versionArg = _versionArgumentBuilder.Build();
        var privilegedOpt = _privilegedOptionBuilder.Build();
        var isEnabledOpt = _enabledOptionBuilder.Build();
        var machineType = _machineTypeOptionBuilder.Build();
        var timeoutStrOpt = TimeoutStrOptionBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("map", "Map Provisioning")
        {
            nameArg,
            provisionNameArg,
            versionArg,
            privilegedOpt,
            isEnabledOpt,
            machineType,
            timeoutStrOpt,
            workingDirOpt
        };

        var binder = new DefineProvisioningMapCommandIntegrationPayloadBinder(
            nameArg,
            provisionNameArg,
            versionArg,
            privilegedOpt,
            isEnabledOpt,
            machineType,
            timeoutStrOpt,
            workingDirOpt
        );

        command.SetHandler(async context =>
        {
            DefineProvisioningMapCommandIntegrationPayload? payload = binder.GetBoundValue(context);

            IDefineProvisioningMapCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            requestBuilder
                .UsingProvisioning(payload.Provision)
                .Version(payload.Version)
                .UsingNames(new[] { payload.MachineName })
                .Privileged(payload.Privileged)
                ;

            requestBuilder.MachineType(payload.MachineType.HasValue && payload.MachineType.Value);

            requestBuilder.Enabled(payload.Enable);
            IDefineProvisioningMapCommandRequest? request = requestBuilder.Build();

            IDefineProvisioningMapCommandResponse? response = await _command.ExecuteAsync(request);
        });

        rootCommand.AddCommand(command);
    }
}