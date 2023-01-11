#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Response;

public class FmtCommandResponseBuilderFactory : IFmtCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FmtCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IFmtCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IFmtCommandResponseBuilder>();
    }
}