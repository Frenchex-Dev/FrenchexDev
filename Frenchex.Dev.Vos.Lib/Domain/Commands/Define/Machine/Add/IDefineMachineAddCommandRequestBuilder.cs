using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add;

public interface IDefineMachineAddCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineMachineAddCommandRequestBuilder UsingDefinition(MachineDefinitionDeclaration definitionDeclaration);
    IDefineMachineAddCommandRequest Build();
}