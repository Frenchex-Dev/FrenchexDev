using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

public interface ISshConfigCommandRequestBuilder : IRootCommandRequestBuilder
{
    ISshConfigCommandRequest Build();
    ISshConfigCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds);
    ISshConfigCommandRequestBuilder UsingHost(string host);
}