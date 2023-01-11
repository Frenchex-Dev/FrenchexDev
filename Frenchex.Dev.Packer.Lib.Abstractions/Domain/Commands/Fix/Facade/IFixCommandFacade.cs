#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Facade;

public interface
    IFixCommandFacade : IFacableCommand, IFacade<IFixCommand, IFixCommandRequestBuilderFactory,
        IFixCommandRequestBuilder>
{
}