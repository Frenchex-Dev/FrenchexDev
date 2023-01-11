#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;

public interface IFmtCommand : IFacableCommand,
    ICommand<IFmtCommandRequest, IFmtCommandResponse>
{
}