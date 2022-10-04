using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IServicesConfiguration
{
    void ConfigureServices(IServiceCollection services);
}