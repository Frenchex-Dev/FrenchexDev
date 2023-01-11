#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;

public interface IValidateCommand : IFacableCommand,
    ICommand<IValidateCommandRequest, IValidateCommandResponse>
{
}