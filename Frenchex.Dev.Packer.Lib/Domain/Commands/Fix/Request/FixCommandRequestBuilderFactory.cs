#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Request;

public class FixCommandRequestBuilderFactory : IFixCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FixCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IFixCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IFixCommandRequestBuilder>();
    }
}