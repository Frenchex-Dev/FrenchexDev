using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

public interface IUpCommandCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IUpCommandCommandResponseBuilder Factory();
}