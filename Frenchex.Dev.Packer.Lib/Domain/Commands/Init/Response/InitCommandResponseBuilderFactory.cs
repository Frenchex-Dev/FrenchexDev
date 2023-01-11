#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Response;

public class InitCommandResponseBuilderFactory : IInitCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public InitCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IInitCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IInitCommandResponseBuilder>();
    }
}