﻿using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;

public class DefineMachineTypeAddCommand : RootCommand, IDefineMachineTypeAddCommand
{
    private readonly IConfigurationSaveAction _configurationSaveAction;

    private readonly IDefineMachineTypeAddCommandResponseBuilderFactory
        _defineMachineTypeAddCommandResponseBuilderFactory;

    public DefineMachineTypeAddCommand(
        IConfigurationLoadAction configurationLoadAction,
        IConfigurationSaveAction configurationSaveAction,
        IDefineMachineTypeAddCommandResponseBuilderFactory defineMachineTypeAddCommandResponseBuilderFactory,
        IVexNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _configurationSaveAction = configurationSaveAction;
        _defineMachineTypeAddCommandResponseBuilderFactory = defineMachineTypeAddCommandResponseBuilderFactory;
    }

    public async Task<IDefineMachineTypeAddCommandResponse> ExecuteAsync(IDefineMachineTypeAddCommandRequest request)
    {
        var configFilePath = Path.Join(request.BaseCommand.WorkingDirectory, "config.json");
        var config = await ConfigurationLoadAction.Load(configFilePath);

        if (request.DefinitionDeclaration.Name != null)
            config.MachineTypes.Add(request.DefinitionDeclaration.Name, request.DefinitionDeclaration);

        await _configurationSaveAction.Save(config, configFilePath);

        return _defineMachineTypeAddCommandResponseBuilderFactory
            .Factory()
            .Build();
    }
}