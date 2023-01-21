#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Configuration;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

public abstract class RootCommand
{
    protected readonly IConfigurationLoadAction ConfigurationLoadAction;
    protected readonly IVosNameToVagrantNameConverter NameToVagrantNameConverter;

    protected RootCommand(
        IConfigurationLoadAction configurationLoadAction,
        IVosNameToVagrantNameConverter nameConverter
    )
    {
        ConfigurationLoadAction = configurationLoadAction;
        NameToVagrantNameConverter = nameConverter;
    }

    protected async Task<Configuration> ConfigurationLoad(string? path)
    {
        if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

        return await ConfigurationLoadAction.Load(path);
    }

    protected string[] MapNamesToVagrantNames(
        string[] names,
        string? workingDirectory,
        Configuration configuration
    )
    {
        return NameToVagrantNameConverter.ConvertAll(names, workingDirectory, configuration);
    }

    protected string[] MapNamesToMachineNames(
        string[] names,
        string? workingDirectory,
        Configuration configuration)
    {
        return NameToVagrantNameConverter.GetMachineNames(names, workingDirectory, configuration);
    }
}