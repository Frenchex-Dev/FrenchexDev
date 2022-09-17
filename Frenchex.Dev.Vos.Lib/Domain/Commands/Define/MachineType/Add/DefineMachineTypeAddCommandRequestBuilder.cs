using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;

public class DefineMachineTypeAddCommandRequestBuilder : IDefineMachineTypeAddCommandRequestBuilder
{
    private MachineTypeDefinitionDeclaration? _definition;

    public DefineMachineTypeAddCommandRequestBuilder(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        BaseBuilder = baseRequestBuilderFactory.Factory(this);
    }

    public IBaseRequestBuilder BaseBuilder { get; }


    public IDefineMachineTypeAddCommandRequestBuilder UsingDefinition(
        MachineTypeDefinitionDeclaration definitionDeclaration
    )
    {
        _definition = definitionDeclaration;
        return this;
    }

    public IDefineMachineTypeAddCommandRequest Build()
    {
        if (null == _definition) throw new InvalidOperationException("_definition is null");

        return new DefineMachineTypeAddCommandRequest(BaseBuilder.Build(), _definition);
    }
}