using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;

public interface IStatusCommandRequestBuilderFactory: IRootCommandRequestBuilderFactory
{
    IStatusCommandRequestBuilder Factory();
}