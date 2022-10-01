using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Command;

public class PluginsCommand : IPluginsCommand
{
    public string GetCliCommandName()
    {
        return "plugins";
    }


    public IPluginsCommandResponse StartProcess(IPluginsCommandRequest request)
    {
        throw new NotImplementedException();
    }
}