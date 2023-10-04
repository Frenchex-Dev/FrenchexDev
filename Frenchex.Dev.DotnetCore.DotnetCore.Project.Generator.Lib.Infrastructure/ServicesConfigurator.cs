using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Infrastructure;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services.AddTransient<IProjectGenerator, ProjectGenerator>();
    }
}