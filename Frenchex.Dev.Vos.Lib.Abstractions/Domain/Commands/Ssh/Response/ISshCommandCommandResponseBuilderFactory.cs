using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;

public interface ISshCommandCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    ISshCommandCommandResponseBuilder Build();
}