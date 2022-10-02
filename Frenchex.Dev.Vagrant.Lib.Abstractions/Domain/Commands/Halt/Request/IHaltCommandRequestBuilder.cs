using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilder : IRootCommandRequestBuilder
{
    IHaltCommandRequest Build();
    IHaltCommandRequestBuilder UsingNamesOrIds(string[] namesOrIds);
    IHaltCommandRequestBuilder UsingHaltTimeout(string? timeout);
    IHaltCommandRequestBuilder WithForce(bool with);
}