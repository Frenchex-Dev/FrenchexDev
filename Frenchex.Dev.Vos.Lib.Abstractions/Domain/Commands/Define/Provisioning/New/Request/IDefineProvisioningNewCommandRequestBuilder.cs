using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Request;

public interface IDefineProvisioningNewCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineProvisioningNewCommandRequest Build();
}