using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Facade;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands;

public class CommandsFacade : ICommandsFacade
{
    public CommandsFacade(
        IBuildCommandFacade buildCommandFacade,
        IConsoleCommandFacade consoleCommandFacade,
        IFixCommandFacade fixCommandFacade,
        IFmtCommandFacade fmtCommandFacade,
        IHcl2UpgradeCommandFacade hcl2UpgradeCommandFacade,
        IInitCommandFacade initCommandFacade,
        IInspectCommandFacade inspectCommandFacade,
        IPluginsCommandFacade pluginsCommandFacade,
        IValidateCommandFacade validateCommandFacade
    )
    {
        BuildCommandFacade = buildCommandFacade;
        ConsoleCommandFacade = consoleCommandFacade;
        FixCommandFacade = fixCommandFacade;
        FmtCommandFacade = fmtCommandFacade;
        Hcl2UpgradeCommandFacade = hcl2UpgradeCommandFacade;
        InitCommandFacade = initCommandFacade;
        InspectCommandFacade = inspectCommandFacade;
        PluginsCommandFacade = pluginsCommandFacade;
        ValidateCommandFacade = validateCommandFacade;
    }

    public IBuildCommandFacade BuildCommandFacade { get; }
    public IConsoleCommandFacade ConsoleCommandFacade { get; }
    public IFixCommandFacade FixCommandFacade { get; }
    public IFmtCommandFacade FmtCommandFacade { get; }
    public IHcl2UpgradeCommandFacade Hcl2UpgradeCommandFacade { get; }
    public IInitCommandFacade InitCommandFacade { get; }
    public IInspectCommandFacade InspectCommandFacade { get; }
    public IPluginsCommandFacade PluginsCommandFacade { get; }
    public IValidateCommandFacade ValidateCommandFacade { get; }
}