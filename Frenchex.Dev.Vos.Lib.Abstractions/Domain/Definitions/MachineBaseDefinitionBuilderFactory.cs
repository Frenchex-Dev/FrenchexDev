namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class MachineBaseDefinitionBuilderFactory
{
#pragma warning disable CA1822 // Marquer les membres comme étant static
    public MachineBaseDefinitionBuilder Factory()
    {
        return new MachineBaseDefinitionBuilder();
    }
#pragma warning restore CA1822 // Marquer les membres comme étant static
}