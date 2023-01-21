#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Response;

public class DestroyCommandResponseBuilderFactory : RootCommandResponseBuilderFactory,
    IDestroyCommandResponseBuilderFactory
{
    public IDestroyCommandResponseBuilder Build()
    {
        return new DestroyCommandResponseBuilder();
    }
}