using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services.AddTransient<ISolutionGenerator, SolutionGenerator>();
    }
}
