using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Request;

public class ConsoleCommandRequestBuilderFactory : IConsoleCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ConsoleCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IConsoleCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IConsoleCommandRequestBuilder>();
    }
}