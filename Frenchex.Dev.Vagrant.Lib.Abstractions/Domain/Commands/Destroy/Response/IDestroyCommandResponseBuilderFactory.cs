#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;

public interface IDestroyCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IDestroyCommandResponseBuilder Build();
}