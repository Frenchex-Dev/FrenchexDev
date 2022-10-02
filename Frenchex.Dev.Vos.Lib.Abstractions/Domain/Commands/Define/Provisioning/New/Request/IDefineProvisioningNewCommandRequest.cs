using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Request;

public interface IDefineProvisioningNewCommandRequest : IRootCommandRequest
{
    string Name { get; }
    IDictionary<string, string> Env { get; }
    string[] Code { get; }
    OsTypeEnum Os { get; }
}