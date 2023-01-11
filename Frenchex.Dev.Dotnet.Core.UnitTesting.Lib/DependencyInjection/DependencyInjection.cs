#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services
                .AddTransient<UnitTest>()
            ;
    }
}