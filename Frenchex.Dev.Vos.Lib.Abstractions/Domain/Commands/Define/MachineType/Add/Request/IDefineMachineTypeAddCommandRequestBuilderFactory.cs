using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;

public interface IDefineMachineTypeAddCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IDefineMachineTypeAddCommandRequestBuilder Factory();
}