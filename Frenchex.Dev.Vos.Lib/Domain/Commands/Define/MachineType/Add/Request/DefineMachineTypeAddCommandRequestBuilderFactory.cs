using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Request;

public class DefineMachineTypeAddCommandRequestBuilderFactory : IDefineMachineTypeAddCommandRequestBuilderFactory
{
    private readonly IBaseRequestBuilderFactory _baseRequestBuilderFactory;

    public DefineMachineTypeAddCommandRequestBuilderFactory(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        _baseRequestBuilderFactory = baseRequestBuilderFactory;
    }

    public IDefineMachineTypeAddCommandRequestBuilder Factory()
    {
        return new DefineMachineTypeAddCommandRequestBuilder(_baseRequestBuilderFactory);
    }
}