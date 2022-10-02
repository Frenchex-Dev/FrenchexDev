using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

public interface ISshCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    ISshCommandRequestBuilder Factory();
}