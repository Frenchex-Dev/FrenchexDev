using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

public interface ISshConfigCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    ISshConfigCommandRequestBuilder Factory();
}