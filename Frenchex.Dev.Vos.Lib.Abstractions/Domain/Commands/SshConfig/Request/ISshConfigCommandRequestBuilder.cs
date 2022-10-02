using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

public interface ISshConfigCommandRequestBuilder : IRootCommandRequestBuilder
{
    ISshConfigCommandRequest Build();
    ISshConfigCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds);
    ISshConfigCommandRequestBuilder UsingHost(string host);
}