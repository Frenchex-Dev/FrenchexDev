#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelConfiguration : IKernerlConfiguration
{
    public KernelConfiguration(IServicesConfiguration servicesConfiguration)
    {
        ServicesConfiguration = servicesConfiguration;
    }

    public IServicesConfiguration ServicesConfiguration { get; }
}