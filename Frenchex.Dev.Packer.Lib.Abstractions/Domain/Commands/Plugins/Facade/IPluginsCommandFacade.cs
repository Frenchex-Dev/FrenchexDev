using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Facade;

public interface IPluginsCommandFacade : IFacableCommand,
    IFacade<IPluginsCommand, IPluginsCommandRequestBuilderFactory, IPluginsCommandRequestBuilder>
{
}