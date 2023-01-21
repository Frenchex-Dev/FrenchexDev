#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Response;

public class BuildCommandResponseBuilderFactory : IBuildCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public BuildCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IBuildCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IBuildCommandResponseBuilder>();
    }
}