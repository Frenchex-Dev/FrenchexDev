using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Response;

public class FmtCommandResponseBuilderFactory : IFmtCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FmtCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IFmtCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IFmtCommandResponseBuilder>();
    }
}