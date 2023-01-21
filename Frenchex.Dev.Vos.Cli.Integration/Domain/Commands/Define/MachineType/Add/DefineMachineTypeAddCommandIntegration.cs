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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType.Add;

public class DefineMachineTypeAddCommandIntegration : ABaseCommandIntegration, IDefineMachineTypeAddCommandIntegration
{
    private readonly IBoxNameArgumentBuilder _boxNameArgumentBuilder;
    private readonly IBoxVersionArgumentBuilder _boxVersionArgumentBuilder;
    private readonly IDefineMachineTypeAddCommand _command;
    private readonly IEnabled3dOptionBuilder _enabled3dOptionBuilder;
    private readonly IEnabledOptionBuilder _enabledOptionBuilder;
    private readonly IMachineTypeDefinitionBuilderFactory _machineTypeDefinitionBuilder;
    private readonly INameArgumentBuilder _nameArgumentBuilder;
    private readonly IOsTypeArgumentBuilder _osTypeArgumentBuilder;
    private readonly IOsVersionOptionBuilder _osVersionOptionBuilder;
    private readonly IRamMbArgumentBuilder _ramMbArgumentBuilder;
    private readonly IDefineMachineTypeAddCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly IVirtualCpusArgumentBuilder _virtualCpusArgumentBuilder;
    private readonly IVirtualRamMbOptionBuilder _virtualRamMbOptionBuilder;

    public DefineMachineTypeAddCommandIntegration(
        IDefineMachineTypeAddCommand command,
        IDefineMachineTypeAddCommandRequestBuilderFactory responseBuilderFactory,
        IMachineTypeDefinitionBuilderFactory machineTypeDefinitionBuilderFactory,
        INameArgumentBuilder nameArgumentBuilder,
        IBoxNameArgumentBuilder boxNameArgumentBuilder,
        IBoxVersionArgumentBuilder boxVersionArgumentBuilder,
        IVirtualCpusArgumentBuilder virtualCpusArgumentBuilder,
        IRamMbArgumentBuilder ramMbArgumentBuilder,
        IOsTypeArgumentBuilder osTypeArgumentBuilder,
        IOsVersionOptionBuilder osVersionOptionBuilder,
        IEnabledOptionBuilder enabledOptionBuilder,
        IEnabled3dOptionBuilder enabled3dOptionBuilder,
        IVirtualRamMbOptionBuilder virtualRamMbOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = responseBuilderFactory;
        _machineTypeDefinitionBuilder = machineTypeDefinitionBuilderFactory;
        _nameArgumentBuilder = nameArgumentBuilder;
        _boxNameArgumentBuilder = boxNameArgumentBuilder;
        _boxVersionArgumentBuilder = boxVersionArgumentBuilder;
        _virtualCpusArgumentBuilder = virtualCpusArgumentBuilder;
        _ramMbArgumentBuilder = ramMbArgumentBuilder;
        _osTypeArgumentBuilder = osTypeArgumentBuilder;
        _osVersionOptionBuilder = osVersionOptionBuilder;
        _enabledOptionBuilder = enabledOptionBuilder;
        _enabled3dOptionBuilder = enabled3dOptionBuilder;
        _virtualRamMbOptionBuilder = virtualRamMbOptionBuilder;
    }

    public void Integrate(Command rootCommand)
    {
        var nameArg = _nameArgumentBuilder.Build();
        var boxNameArg = _boxNameArgumentBuilder.Build();
        var boxVersionArg = _boxVersionArgumentBuilder.Build();
        var vcpusArg = _virtualCpusArgumentBuilder.Build();
        var ramMbArg = _ramMbArgumentBuilder.Build();
        var osTypeArg = _osTypeArgumentBuilder.Build();
        var osVersionOpt = _osVersionOptionBuilder.Build();
        var isEnabledOpt = _enabledOptionBuilder.Build();
        var isEnabled3dOpt = _enabled3dOptionBuilder.Build();
        var vRamMbOpt = _virtualRamMbOptionBuilder.Build();
        var timeoutStrOpt = TimeoutStrOptionBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("add", "Define Machine-Types")
        {
            nameArg,
            boxNameArg,
            boxVersionArg,
            vcpusArg,
            ramMbArg,
            osTypeArg,

            isEnabledOpt,
            isEnabled3dOpt,
            vRamMbOpt,
            timeoutStrOpt,
            workingDirOpt
        };

        var binder = new DefineMachineTypeAddCommandIntegrationPayloadBinder(
            nameArg,
            boxNameArg,
            boxVersionArg,
            vcpusArg,
            ramMbArg,
            osTypeArg,
            osVersionOpt,
            isEnabledOpt,
            isEnabled3dOpt,
            vRamMbOpt,
            timeoutStrOpt,
            workingDirOpt
        );

        command.SetHandler(async context =>
        {
            DefineMachineTypeAddCommandIntegrationPayload? payload = binder.GetBoundValue(context);

            if (payload.OsType == null)
                throw new ArgumentNullException(nameof(payload.OsType));

            IDefineMachineTypeAddCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            IDefineMachineTypeAddCommandRequest? request = requestBuilder
                .UsingDefinition(_machineTypeDefinitionBuilder.Factory()
                    .BaseBuilder
                    .Enabled(payload.Enabled)
                    .With3DEnabled(payload.Enable3D)
                    .WithBox(payload.BoxName)
                    .WithBoxVersion(payload.BoxVersion)
                    .WithRamInMb(payload.RamInMb)
                    .WithVirtualCpus(payload.VCpus)
                    .WithOsType(Enum.Parse<OsTypeEnum>(payload.OsType))
                    .WithOsVersion(payload.OsVersion)
                    .WithVideoRamInMb(payload.VideoRamInMb)
                    .WithProvider(payload.Provider ?? string.Empty)
                    .Parent<IMachineTypeDefinitionBuilder>()
                    .WithName(payload.Name)
                    .Build()
                )
                .Build();

            IDefineMachineTypeAddCommandResponse? response = await _command.ExecuteAsync(request);
        });

        rootCommand.AddCommand(command);
    }
}