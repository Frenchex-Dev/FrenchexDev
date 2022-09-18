using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;

public class UpCommandRequestBuilderFactory : IUpCommandRequestBuilderFactory
{
    private readonly IBaseCommandRequestBuilderFactory _baseFactory;

    public UpCommandRequestBuilderFactory(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        _baseFactory = baseRequestBuilderFactory;
    }

    public IUpCommandRequestBuilder Factory()
    {
        return new UpCommandRequestBuilder(_baseFactory);
    }
}