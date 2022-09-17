using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class ProgramBuilder : IProgramBuilder
{
    private readonly IHostBuilder _hostBuilder;

    public ProgramBuilder(
        IHostBuilder hostBuilder
    )
    {
        _hostBuilder = hostBuilder;
    }

    public IProgram Build(
        Context context,
        Action<IServiceCollection> registerServices,
        Action<ILoggingBuilder> loggingConfigurationLambda
    )
    {
        return new Program(_hostBuilder.Build(context, registerServices, loggingConfigurationLambda));
    }

    public IProgram Build(
        Context context,
        AsyncServiceScope asyncServiceScope,
        Action<ILoggingBuilder> loggingConfigurationLambda
    )
    {
        return new Program(_hostBuilder.Build(context, asyncServiceScope, loggingConfigurationLambda));
    }
}