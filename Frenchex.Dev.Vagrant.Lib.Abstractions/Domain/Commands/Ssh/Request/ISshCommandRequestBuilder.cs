#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;

public interface ISshCommandRequestBuilder : IRootCommandRequestBuilder
{
    ISshCommandRequest Build();
    ISshCommandRequestBuilder UsingNameOrId(string nameOrId);
    ISshCommandRequestBuilder UsingCommand(string command);
    ISshCommandRequestBuilder WithPlain(bool with);
    ISshCommandRequestBuilder WithColor(bool with);
    ISshCommandRequestBuilder UsingExtraSshArgs(string extraSshArg);
}