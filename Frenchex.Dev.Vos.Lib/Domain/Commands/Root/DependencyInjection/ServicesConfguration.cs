#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Base.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.DependencyInjection;

public static class ServicesConfguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IBaseRequestBuilderFactory, BaseRequestBuilderFactory>()
            .AddTransient<IBaseRequestBuilder, BaseRequestBuilder>()
            ;
    }
}