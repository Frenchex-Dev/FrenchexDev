using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

public interface IUpCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IUpCommandResponseBuilder Factory();
}