#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Response;

public class InitCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IInitCommandResponseBuilderFactory
{
    public IInitCommandResponseBuilder Build()
    {
        return new InitCommandResponseBuilder();
    }
}