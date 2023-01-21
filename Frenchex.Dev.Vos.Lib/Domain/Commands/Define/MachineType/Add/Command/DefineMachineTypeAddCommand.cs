#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Configuration;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Command;

public class DefineMachineTypeAddCommand : RootCommand, IDefineMachineTypeAddCommand
{
    private readonly IConfigurationSaveAction _configurationSaveAction;

    private readonly IDefineMachineTypeAddCommandResponseBuilderFactory
        _defineMachineTypeAddCommandResponseBuilderFactory;

    public DefineMachineTypeAddCommand(
        IConfigurationLoadAction configurationLoadAction,
        IConfigurationSaveAction configurationSaveAction,
        IDefineMachineTypeAddCommandResponseBuilderFactory defineMachineTypeAddCommandResponseBuilderFactory,
        IVosNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _configurationSaveAction = configurationSaveAction;
        _defineMachineTypeAddCommandResponseBuilderFactory = defineMachineTypeAddCommandResponseBuilderFactory;
    }

    public async Task<IDefineMachineTypeAddCommandResponse> ExecuteAsync(IDefineMachineTypeAddCommandRequest request)
    {
        if (string.IsNullOrEmpty(request.BaseCommand.WorkingDirectory))
            throw new ArgumentNullException(nameof(request.BaseCommand.WorkingDirectory));

        Configuration? config = await ConfigurationLoadAction.Load(request.BaseCommand.WorkingDirectory);

        if (request.DefinitionDeclaration.Name != null)
            config.MachineTypes.Add(request.DefinitionDeclaration.Name, request.DefinitionDeclaration);

        await _configurationSaveAction.Save(config, request.BaseCommand.WorkingDirectory);

        return _defineMachineTypeAddCommandResponseBuilderFactory
            .Factory()
            .Build();
    }
}