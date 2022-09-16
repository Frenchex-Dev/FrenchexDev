using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;

public interface IDefineMachineTypeAddCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineMachineTypeAddCommandRequestBuilder UsingDefinition(MachineTypeDefinitionDeclaration definitionDeclaration);
    IDefineMachineTypeAddCommandRequest Build();
}