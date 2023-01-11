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
using Microsoft.Extensions.Hosting;

#endregion

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;

public interface IProgramBuilder
{
    public Task<IProgram> BuildAsync<T>(
        IServiceCollection serviceCollection,
        Action<IServiceCollection> registerServices,
        IContext context
    ) where T : class, IHostedService;
}