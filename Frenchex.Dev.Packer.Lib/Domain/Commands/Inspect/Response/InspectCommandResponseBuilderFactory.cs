#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Response;

public class InspectCommandResponseBuilderFactory : IInspectCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public InspectCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IInspectCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IInspectCommandResponseBuilder>();
    }
}