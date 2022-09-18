using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

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