using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

public class RootCommandRequest : IRootCommandRequest
{
    public RootCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}