#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class MachineTypeDefinitionBuilder : IMachineTypeDefinitionBuilder
{
    private string? _name;

    public MachineTypeDefinitionBuilder(
        MachineBaseDefinitionBuilder baseBuilder
    )
    {
        BaseBuilder = baseBuilder.SetParent(this);
    }

    public MachineBaseDefinitionBuilder BaseBuilder { get; }

    public IMachineTypeDefinitionBuilder WithName(string? name)
    {
        _name = name;
        return this;
    }


    public MachineTypeDefinitionDeclaration Build()
    {
        if (null == _name) throw new InvalidOperationException("name is null");

        return new MachineTypeDefinitionDeclaration { Base = BaseBuilder.Build(), Name = _name };
    }
}