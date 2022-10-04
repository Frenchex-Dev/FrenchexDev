using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Request;

public class DefineMachineAddCommandRequestBuilder : IDefineMachineAddCommandRequestBuilder
{
    private MachineDefinitionDeclaration? _definition;

    public DefineMachineAddCommandRequestBuilder(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        BaseBuilder = baseRequestBuilderFactory.Factory(this);
    }

    public IBaseRequestBuilder BaseBuilder { get; }

    public IDefineMachineAddCommandRequest Build()
    {
        if (null == _definition) throw new InvalidOperationException("definitionDeclaration is null");

        return new DefineMachineAddCommandCommandRequest(
            _definition,
            BaseBuilder.Build()
        );
    }

    public IDefineMachineAddCommandRequestBuilder UsingDefinition(MachineDefinitionDeclaration definitionDeclaration)
    {
        _definition = definitionDeclaration;
        return this;
    }
}