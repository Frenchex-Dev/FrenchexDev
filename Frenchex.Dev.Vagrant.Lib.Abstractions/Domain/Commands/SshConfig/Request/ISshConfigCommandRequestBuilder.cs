using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;

public interface ISshConfigCommandRequestBuilder : IRootCommandRequestBuilder
{
    ISshConfigCommandRequest Build();
    ISshConfigCommandRequestBuilder UsingName(string nameOrId);
    ISshConfigCommandRequestBuilder UsingHost(string host);
}