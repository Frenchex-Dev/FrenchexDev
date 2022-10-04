using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Command;

public class DefineMachineAddCommand : RootCommand, IDefineMachineAddCommand
{
    private readonly IConfigurationSaveAction _configurationSaveAction;
    private readonly IDefineMachineAddCommandResponseBuilderFactory _responseBuilderFactory;

    public DefineMachineAddCommand(
        IConfigurationLoadAction configurationLoadAction,
        IConfigurationSaveAction configurationSaveAction,
        IDefineMachineAddCommandResponseBuilderFactory responseBuilderFactory,
        IVexNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _configurationSaveAction = configurationSaveAction;
        _responseBuilderFactory = responseBuilderFactory;
    }

    public async Task<IDefineMachineAddCommandResponse> ExecuteAsync(IDefineMachineAddCommandRequest request)
    {
        if (null == request.DefinitionDeclaration.Name)
            throw new InvalidOperationException("request or definitionDeclaration or name is null");

        var configFilePath = Path.Join(request.BaseCommand.WorkingDirectory, "config.json");
        var config = await ConfigurationLoadAction.Load(configFilePath);

        config.Machines.Add(request.DefinitionDeclaration.Name, request.DefinitionDeclaration);

        await _configurationSaveAction.Save(config, configFilePath);

        return _responseBuilderFactory
            .Factory()
            .Build();
    }
}