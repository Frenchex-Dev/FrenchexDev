#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class HostBasedHostBasedProgramBuilder : IHostBasedProgramBuilder
{
    private readonly IHostBuilder _hostBuilder;

    public HostBasedHostBasedProgramBuilder(
        IHostBuilder hostBuilder
    )
    {
        _hostBuilder = hostBuilder;
    }

    public IProgram Build(
        IContext context,
        Action<IServiceCollection> registerServices,
        Action<IServiceCollection> registerHostedServices,
        Action<ILoggingBuilder> loggingConfigurationLambda
    )
    {
        return new HostBasedProgram(_hostBuilder.Build(context,
            services =>
            {
                registerServices.Invoke(services);
                registerHostedServices.Invoke(services);
            },
            loggingConfigurationLambda));
    }

    public IProgram Build(
        IContext context,
        AsyncServiceScope asyncServiceScope,
        Action<ILoggingBuilder> loggingConfigurationLambda
    )
    {
        return new HostBasedProgram(_hostBuilder.Build(context, asyncServiceScope, loggingConfigurationLambda));
    }
}