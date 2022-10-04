using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;

public interface IDefineMachineAddCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineMachineAddCommandRequestBuilder UsingDefinition(MachineDefinitionDeclaration definitionDeclaration);
    IDefineMachineAddCommandRequest Build();
}