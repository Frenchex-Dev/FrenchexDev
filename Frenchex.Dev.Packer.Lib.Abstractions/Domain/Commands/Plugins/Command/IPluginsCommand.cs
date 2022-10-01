using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Command;

public interface IPluginsCommand : IFacableCommand,
    ICommand<IPluginsCommandRequest, IPluginsCommandResponse>
{
}