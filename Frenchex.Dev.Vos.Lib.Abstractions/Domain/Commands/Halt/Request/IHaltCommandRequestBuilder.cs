using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilder : IRootCommandRequestBuilder
{
    IHaltCommandRequest Build();
    IHaltCommandRequestBuilder UsingNames(string[]? names);
    IHaltCommandRequestBuilder WithForce(bool with);
    IHaltCommandRequestBuilder UsingHaltTimeout(string? timeout);
}