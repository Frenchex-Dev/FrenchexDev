using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.New;

public interface IDefineProvisioningNewCommandRequest : IRootCommandRequest
{
    string Name { get; }
    IDictionary<string, string> Env { get; }
    string[] Code { get; }
    OsTypeEnum Os { get; }
}