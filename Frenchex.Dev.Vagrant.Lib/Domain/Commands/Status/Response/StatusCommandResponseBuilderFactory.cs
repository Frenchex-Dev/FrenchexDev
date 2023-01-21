#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponseBuilderFactory : RootCommandResponseBuilderFactory,
    IStatusCommandResponseBuilderFactory
{
    public IStatusCommandResponseBuilder Build()
    {
        return new StatusCommandResponseBuilder();
    }
}