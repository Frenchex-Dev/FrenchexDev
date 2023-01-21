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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Configuration;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Command;

public class DefineProvisioningMapCommand : RootCommand, IDefineProvisioningMapCommand
{
    private readonly IConfigurationSaveAction _configurationSaveAction;
    private readonly IDefineProvisioningMapCommandResponseBuilderFactory _responseBuilderFactory;

    public DefineProvisioningMapCommand(
        IDefineProvisioningMapCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IConfigurationSaveAction configurationSaveAction,
        IVosNameToVagrantNameConverter nameConverter
    ) : base(configurationLoadAction, nameConverter)
    {
        _responseBuilderFactory = responseBuilderFactory;
        _configurationSaveAction = configurationSaveAction;
    }

    public async Task<IDefineProvisioningMapCommandResponse> ExecuteAsync(IDefineProvisioningMapCommandRequest request)
    {
        Configuration? config = await ConfigurationLoad(request.BaseCommand.WorkingDirectory);

        if (config is null) throw new ArgumentNullException(nameof(config));

        string[]? names = MapNamesToMachineNames(request.Names, request.BaseCommand.WorkingDirectory, config);

        foreach (string? name in names)
        {
            MachineBaseDefinitionDeclaration? definition = null;

            if (request.MachineType)
            {
                if (config.MachineTypes.ContainsKey(name)) definition = config.MachineTypes[name].Base;
            }
            else
            {
                if (config.Machines.ContainsKey(name)) definition = config.Machines[name].Base;
            }

            if (definition is null) definition = new MachineBaseDefinitionDeclaration();

            if (definition.Provisioning is null)
                definition.Provisioning = new Dictionary<string, ProvisioningDefinition>();

            definition.Provisioning.Add(request.ProvisioningName, new ProvisioningDefinition
            {
                Version = request.Version,
                Env = request.Env,
                Privileged = request.Privileged
            });
        }

        await _configurationSaveAction.Save(config!, request.BaseCommand.WorkingDirectory!);

        return _responseBuilderFactory.Factory().Build();
    }
}