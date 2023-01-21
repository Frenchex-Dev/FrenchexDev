#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Facade;

public interface IValidateCommandFacade : IFacableCommand,
    IFacade<IValidateCommand, IValidateCommandRequestBuilderFactory, IValidateCommandRequestBuilder>
{
}