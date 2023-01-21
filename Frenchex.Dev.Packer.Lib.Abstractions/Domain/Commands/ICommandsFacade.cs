#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Facade;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands;

public interface ICommandsFacade
{
    IBuildCommandFacade BuildCommandFacade { get; }
    IConsoleCommandFacade ConsoleCommandFacade { get; }
    IFixCommandFacade FixCommandFacade { get; }
    IFmtCommandFacade FmtCommandFacade { get; }
    IHcl2UpgradeCommandFacade Hcl2UpgradeCommandFacade { get; }
    IInitCommandFacade InitCommandFacade { get; }
    IInspectCommandFacade InspectCommandFacade { get; }
    IPluginsCommandFacade PluginsCommandFacade { get; }
    IValidateCommandFacade ValidateCommandFacade { get; }
}