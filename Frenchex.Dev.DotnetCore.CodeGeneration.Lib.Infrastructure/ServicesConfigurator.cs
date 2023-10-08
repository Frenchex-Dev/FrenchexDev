#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain;
using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Infrastructure;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        services
            .AddTransient<IFileWriter, FileWriter>()
            .AddTransient<IGeneratedCodeWriter, GeneratedCodeWriter>()
            .AddTransient<IGeneratedCodeWriterOptions>(
                                                       _ => new GeneratedCodeWriterOptions
                                                            {
                                                                WriteFilesMaxConcurrency = 500 //@todo make it using IOptions pattern
                                                            });
    }
}
