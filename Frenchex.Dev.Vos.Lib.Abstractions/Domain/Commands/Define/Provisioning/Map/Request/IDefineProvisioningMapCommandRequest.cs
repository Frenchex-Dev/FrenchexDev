using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

public interface IDefineProvisioningMapCommandRequest : IRootCommandRequest
{
    string Provisioning { get; }
    IDictionary<string, string> Env { get; }
}