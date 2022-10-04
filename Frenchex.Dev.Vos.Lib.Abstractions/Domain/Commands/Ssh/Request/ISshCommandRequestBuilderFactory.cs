using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

public interface ISshCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    ISshCommandRequestBuilder Factory();
}