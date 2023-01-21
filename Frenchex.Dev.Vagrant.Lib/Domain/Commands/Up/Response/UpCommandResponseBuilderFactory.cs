#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Response;

public class UpCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IUpCommandResponseBuilderFactory
{
    public IUpCommandResponseBuilder Build()
    {
        return new UpCommandResponseBuilder();
    }
}