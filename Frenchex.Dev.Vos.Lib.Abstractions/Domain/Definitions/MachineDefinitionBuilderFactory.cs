#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class MachineDefinitionBuilderFactory
{
    private readonly MachineBaseDefinitionBuilderFactory _baseDefinitionBuilderFactory;

    public MachineDefinitionBuilderFactory(
        MachineBaseDefinitionBuilderFactory baseDefinitionBuilderFactory
    )
    {
        _baseDefinitionBuilderFactory = baseDefinitionBuilderFactory;
    }

    public MachineDefinitionBuilder Factory()
    {
        return new MachineDefinitionBuilder(_baseDefinitionBuilderFactory.Factory());
    }
}