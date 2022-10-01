using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Plugins.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Plugins.Request;

public class PluginsCommandRequest : IPluginsCommandRequest
{
    public PluginsCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}