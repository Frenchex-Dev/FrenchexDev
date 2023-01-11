#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Request;

public class FmtCommandRequestBuilderFactory : IFmtCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FmtCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IFmtCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IFmtCommandRequestBuilder>();
    }
}