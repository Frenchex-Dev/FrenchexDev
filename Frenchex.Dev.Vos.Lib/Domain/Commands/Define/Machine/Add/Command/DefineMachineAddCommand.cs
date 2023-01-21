#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Command;

public class DefineMachineAddCommand : RootCommand, IDefineMachineAddCommand
{
    private readonly IConfigurationSaveAction _configurationSaveAction;
    private readonly IDefineMachineAddCommandResponseBuilderFactory _responseBuilderFactory;

    public DefineMachineAddCommand(
        IConfigurationLoadAction configurationLoadAction,
        IConfigurationSaveAction configurationSaveAction,
        IDefineMachineAddCommandResponseBuilderFactory responseBuilderFactory,
        IVosNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _configurationSaveAction = configurationSaveAction;
        _responseBuilderFactory = responseBuilderFactory;
    }

    public async Task<IDefineMachineAddCommandResponse> ExecuteAsync(IDefineMachineAddCommandRequest request)
    {
        if (null == request.DefinitionDeclaration.Name)
            throw new InvalidOperationException("request or definitionDeclaration or name is null");

        if (null == request.BaseCommand)
        {
            throw new ArgumentNullException(nameof(request.BaseCommand));
        }

        if (string.IsNullOrEmpty(request.BaseCommand.WorkingDirectory))
        {
            throw new ArgumentNullException(nameof(request.BaseCommand.WorkingDirectory));
        }

        var config = await ConfigurationLoadAction.Load(request.BaseCommand.WorkingDirectory);

        config.Machines.Add(request.DefinitionDeclaration.Name, request.DefinitionDeclaration);

        await _configurationSaveAction.Save(config, request.BaseCommand.WorkingDirectory);

        return _responseBuilderFactory
            .Factory()
            .Build();
    }
}