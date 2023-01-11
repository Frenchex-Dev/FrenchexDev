#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;

public interface IFixCommand : IFacableCommand, ICommand<IFixCommandRequest, IFixCommandResponse>
{
}