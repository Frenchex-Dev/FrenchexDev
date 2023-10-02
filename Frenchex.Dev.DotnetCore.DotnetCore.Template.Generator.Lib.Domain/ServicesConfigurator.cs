using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services.AddTransient<ITemplateGenerator, TemplateGenerator>()
                .AddTransient<IProjectTemplateGenerator, ProjectTemplateGenerator>();
    }
}
