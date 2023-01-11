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
using Frenchex.Dev.Dotnet.Core.Cli.Lib.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class ExecutionContextBuilder : IExecutionContextBuilder
{
    public IExecutionContext Build()
    {
        IServiceCollection coreServices = new ServiceCollection();
        ServicesConfiguration.StaticConfigureServices(coreServices);
        var coreServicesProvider = coreServices.BuildServiceProvider();

        return new ExecutionContext { AsyncScope = coreServicesProvider.CreateAsyncScope() };
    }
}