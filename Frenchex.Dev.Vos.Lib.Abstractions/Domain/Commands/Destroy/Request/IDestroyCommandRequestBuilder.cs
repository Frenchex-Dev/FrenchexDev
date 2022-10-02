using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDestroyCommandRequestBuilder UsingName(string? name);
    IDestroyCommandRequestBuilder WithForce(bool force);
    IDestroyCommandRequestBuilder WithParallel(bool parallel);
    IDestroyCommandRequestBuilder WithGraceful(bool graceful);
    IDestroyCommandRequestBuilder UsingDestroyTimeout(string timeout);
    IDestroyCommandRequest Build();
}