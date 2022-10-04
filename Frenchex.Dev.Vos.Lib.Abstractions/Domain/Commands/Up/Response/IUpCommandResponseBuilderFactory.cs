using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

public interface IUpCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IUpCommandResponseBuilder Factory();
}