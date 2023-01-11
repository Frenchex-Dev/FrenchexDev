#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IServicesConfiguration
{
    void ConfigureServices(IServiceCollection services);
}