using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;

public interface IDestroyCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IDestroyCommandResponseBuilder Build();
}