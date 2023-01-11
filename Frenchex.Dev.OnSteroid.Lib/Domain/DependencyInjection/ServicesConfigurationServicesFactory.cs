#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;

public class ServicesConfigurationServicesFactory : IServicesConfigurationServicesFactory
{
    public IServicesConfigurationServices Factory()
    {
        return new ServicesConfigurationServices();
    }
}