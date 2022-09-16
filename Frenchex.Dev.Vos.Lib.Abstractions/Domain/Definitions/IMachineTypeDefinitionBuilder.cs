namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public interface IMachineTypeDefinitionBuilder
{
    public MachineBaseDefinitionBuilder BaseBuilder { get; }
    public IMachineTypeDefinitionBuilder WithName(string? name);

    public MachineTypeDefinitionDeclaration Build();
}