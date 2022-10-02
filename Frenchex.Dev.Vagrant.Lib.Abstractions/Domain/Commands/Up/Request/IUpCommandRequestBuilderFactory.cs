using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;

public interface IUpCommandRequestBuilderFactory: IRootCommandRequestBuilderFactory
{
    IUpCommandRequestBuilder Factory();
}