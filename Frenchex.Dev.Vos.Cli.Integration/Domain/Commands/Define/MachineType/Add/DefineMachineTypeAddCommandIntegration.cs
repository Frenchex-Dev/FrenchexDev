using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType.Add;

public class DefineMachineTypeAddCommandIntegration : ABaseCommandIntegration, IDefineMachineTypeAddCommandIntegration
{
    private readonly IBoxNameArgumentBuilder _boxNameArgumentBuilder;
    private readonly IDefineMachineTypeAddCommand _command;
    private readonly IEnabled3dOptionBuilder _enabled3dOptionBuilder;
    private readonly IEnabledOptionBuilder _enabledOptionBuilder;
    private readonly IMachineTypeDefinitionBuilderFactory _machineTypeDefinitionBuilder;
    private readonly INameArgumentBuilder _nameArgumentBuilder;
    private readonly IOsTypeArgumentBuilder _osTypeArgumentBuilder;
    private readonly IOsVersionArgumentBuilder _osVersionArgumentBuilder;
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
        IVirtualCpusArgumentBuilder virtualCpusArgumentBuilder,
        IRamMbArgumentBuilder ramMbArgumentBuilder,
        IOsTypeArgumentBuilder osTypeArgumentBuilder,
        IOsVersionArgumentBuilder osVersionArgumentBuilder,
        IEnabledOptionBuilder enabledOptionBuilder,
        IEnabled3dOptionBuilder enabled3dOptionBuilder,
        IVirtualRamMbOptionBuilder virtualRamMbOptionBuilder,
        ITimeoutMsOptionBuilder timeoutMsOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutMsOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = responseBuilderFactory;
        _machineTypeDefinitionBuilder = machineTypeDefinitionBuilderFactory;
        _nameArgumentBuilder = nameArgumentBuilder;
        _boxNameArgumentBuilder = boxNameArgumentBuilder;
        _virtualCpusArgumentBuilder = virtualCpusArgumentBuilder;
        _ramMbArgumentBuilder = ramMbArgumentBuilder;
        _osTypeArgumentBuilder = osTypeArgumentBuilder;
        _osVersionArgumentBuilder = osVersionArgumentBuilder;
        _enabledOptionBuilder = enabledOptionBuilder;
        _enabled3dOptionBuilder = enabled3dOptionBuilder;
        _virtualRamMbOptionBuilder = virtualRamMbOptionBuilder;
    }

    public void Integrate(Command rootCommand)
    {
        Argument<string> nameArg = _nameArgumentBuilder.Build();
        Argument<string> boxNameArg = _boxNameArgumentBuilder.Build();
        Argument<int> vcpusArg = _virtualCpusArgumentBuilder.Build();
        Argument<int> ramMbArg = _ramMbArgumentBuilder.Build();
        Argument<string> osTypeArg = _osTypeArgumentBuilder.Build();
        Argument<string> osVersionArg = _osVersionArgumentBuilder.Build();
        Option<bool> isEnabledOpt = _enabledOptionBuilder.Build();
        Option<bool> isEnabled3dOpt = _enabled3dOptionBuilder.Build();
        Option<int> vramMbOpt = _virtualRamMbOptionBuilder.Build();
        Option<int> timeoutMsOpt = TimeoutMsOptionBuilder.Build();
        Option<string> workingDirOpt = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("add", "Define Machine-Types") {
            nameArg,
            boxNameArg,
            vcpusArg,
            ramMbArg,
            osTypeArg,
            osVersionArg,
            isEnabledOpt,
            isEnabled3dOpt,
            vramMbOpt,
            timeoutMsOpt,
            workingDirOpt
        };

        var binder = new DefineMachineTypeAddCommandIntegrationPayloadBinder(
            nameArg,
            boxNameArg,
            vcpusArg,
            ramMbArg,
            osTypeArg,
            osVersionArg,
            isEnabledOpt,
            isEnabled3dOpt,
            vramMbOpt,
            timeoutMsOpt,
            workingDirOpt
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);

            if (payload.OsType == null)
                throw new ArgumentNullException(nameof(payload.OsType));

            var requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            var request = requestBuilder
                .UsingDefinition(_machineTypeDefinitionBuilder.Factory()
                    .BaseBuilder
                    .Enabled(payload.Enabled)
                    .With3DEnabled(payload.Enable3D)
                    .WithBox(payload.BoxName)
                    .WithRamInMb(payload.RamInMb)
                    .WithVirtualCpus(payload.VCpus)
                    .WithOsType(Enum.Parse<OsTypeEnum>(payload.OsType))
                    .WithVideoRamInMb(payload.VideoRamInMb)
                    .WithProvider(payload.Provider ?? string.Empty)
                    .Parent<IMachineTypeDefinitionBuilder>()
                    .WithName(payload.Name)
                    .Build()
                )
                .Build();

            var response = await _command.ExecuteAsync(request);
        });

        rootCommand.AddCommand(command);
    }
}