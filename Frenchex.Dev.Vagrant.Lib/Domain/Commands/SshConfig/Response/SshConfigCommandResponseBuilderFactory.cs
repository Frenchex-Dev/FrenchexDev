#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Response;

public class SshConfigCommandResponseBuilderFactory : RootCommandResponseBuilderFactory,
    ISshConfigCommandResponseBuilderFactory
{
    public ISshConfigCommandResponseBuilder Build()
    {
        return new SshConfigCommandResponseBuilder();
    }
}