using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;

public interface IDefineMachineTypeAddCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineMachineTypeAddCommandRequestBuilder UsingDefinition(MachineTypeDefinitionDeclaration definitionDeclaration);
    IDefineMachineTypeAddCommandRequest Build();
}