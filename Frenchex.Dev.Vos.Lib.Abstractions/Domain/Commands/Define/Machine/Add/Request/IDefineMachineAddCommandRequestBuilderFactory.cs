using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;

public interface IDefineMachineAddCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IDefineMachineAddCommandRequestBuilder Factory();
}