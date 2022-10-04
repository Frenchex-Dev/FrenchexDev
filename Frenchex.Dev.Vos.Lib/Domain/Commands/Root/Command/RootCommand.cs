using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Configuration;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

public abstract class RootCommand
{
    protected readonly IConfigurationLoadAction ConfigurationLoadAction;
    protected readonly IVexNameToVagrantNameConverter NameToVagrantNameConverter;

    protected RootCommand(
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter nameConverter
    )
    {
        ConfigurationLoadAction = configurationLoadAction;
        NameToVagrantNameConverter = nameConverter;
    }

    protected async Task<Configuration> ConfigurationLoad(string? path)
    {
        return await ConfigurationLoadAction.Load(Path.Join(path, "config.json"));
    }

    protected string[] MapNamesToVagrantNames(
        string[] names,
        string? workingDirectory,
        Configuration configuration
    )
    {
        return NameToVagrantNameConverter.ConvertAll(names, workingDirectory, configuration);
    }
}