#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public interface IMachineTypeDefinitionBuilderFactory
{
    IMachineTypeDefinitionBuilder Factory();
}