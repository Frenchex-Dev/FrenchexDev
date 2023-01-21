#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning.Map;

public class DefineProvisioningMapCommandIntegration : ABaseCommandIntegration, IDefineProvisioningMapCommandIntegration
{
    private readonly IDefineProvisioningMapCommand _command;
    private readonly IDefineProvisioningMapCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly INameArgumentBuilder _nameArgumentBuilder;
    private readonly IProvisionNameArgumentBuilder _provisionNameArgumentBuilder;
    private readonly IEnabledOptionBuilder _enabledOptionBuilder;
    private readonly IMachineTypeOptionBuilder _machineTypeOptionBuilder;
    private readonly IVersionArgumentBuilder _versionArgumentBuilder;

    public DefineProvisioningMapCommandIntegration(
        IDefineProvisioningMapCommand command,
        IDefineProvisioningMapCommandRequestBuilderFactory requestBuilderFactory,
        INameArgumentBuilder nameArgumentBuilder,
        IProvisionNameArgumentBuilder provisionNameArgumentBuilder,
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
        _enabledOptionBuilder = enabledOptionBuilder;
        _machineTypeOptionBuilder = machineTypeOptionBuilder;
        _versionArgumentBuilder = versionArgumentBuilder;
    }

    public void Integrate(Command rootCommand)
    {
        Argument<string> nameArg = _nameArgumentBuilder.Build();
        Argument<string> provisionNameArg = _provisionNameArgumentBuilder.Build();
        Argument<string> versionArg = _versionArgumentBuilder.Build();
        Option<bool> isEnabledOpt = _enabledOptionBuilder.Build();
        Option<bool> machineType = _machineTypeOptionBuilder.Build();
        Option<string>? timeoutStrOpt = TimeoutStrOptionBuilder.Build();
        Option<string>? workingDirOpt = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("map", "Map Provisioning")
        {
            nameArg,
            provisionNameArg,
            versionArg,
            isEnabledOpt,
            machineType,
            timeoutStrOpt,
            workingDirOpt
        };

        var binder = new DefineProvisioningMapCommandIntegrationPayloadBinder(
            nameArg,
            provisionNameArg,
            versionArg,
            isEnabledOpt,
            machineType,
            timeoutStrOpt,
            workingDirOpt
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);

            var requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            requestBuilder
                .UsingProvisioning(payload.Provision)
                .Version(payload.Version)
                .UsingNames(new[] { payload.MachineName })
                ;

            if (payload.MachineType.HasValue && payload.MachineType.Value)
            {
                requestBuilder.MachineType();
            }
            else
            {
                requestBuilder.Machine();
            }

            if (payload.Enable)
            {
                requestBuilder.Enable();
            }
            else
            {
                requestBuilder.Disable();
            }

            var request = requestBuilder.Build();

            var response = await _command.ExecuteAsync(request);
        });

        rootCommand.AddCommand(command);
    }
}