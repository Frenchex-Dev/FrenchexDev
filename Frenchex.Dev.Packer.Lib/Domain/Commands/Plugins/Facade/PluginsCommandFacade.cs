using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Facade;

public class PluginsCommandFacade : IPluginsCommandFacade
{
    public PluginsCommandFacade(
        IPluginsCommand command,
        IPluginsCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }


    public string GetCliCommandName()
    {
        return "plugins";
    }

    public IPluginsCommand Command { get; }
    public IPluginsCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IPluginsCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}