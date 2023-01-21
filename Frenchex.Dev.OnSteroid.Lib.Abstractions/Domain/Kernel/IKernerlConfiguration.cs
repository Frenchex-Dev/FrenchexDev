#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

public interface IKernerlConfiguration
{
    IServicesConfiguration ServicesConfiguration { get; }
}