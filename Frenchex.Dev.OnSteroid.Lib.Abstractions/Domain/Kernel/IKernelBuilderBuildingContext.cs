#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

public interface IKernelBuilderBuildingContext
{
    IKernel Build();
}