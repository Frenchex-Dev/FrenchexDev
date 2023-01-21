#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Response;

public class SshCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, ISshCommandResponseBuilderFactory
{
    public ISshCommandResponseBuilder Build()
    {
        return new SshCommandResponseBuilder();
    }
}