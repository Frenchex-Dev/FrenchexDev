namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class MachineTypeDefinitionBuilderFactory : IMachineTypeDefinitionBuilderFactory
{
    private readonly MachineBaseDefinitionBuilderFactory _baseDefinitionBuilderFactory;

    public MachineTypeDefinitionBuilderFactory(
        MachineBaseDefinitionBuilderFactory baseDefinitionBuilderFactory
    )
    {
        _baseDefinitionBuilderFactory = baseDefinitionBuilderFactory;
    }

    public IMachineTypeDefinitionBuilder Factory()
    {
        return new MachineTypeDefinitionBuilder(_baseDefinitionBuilderFactory.Factory());
    }
}