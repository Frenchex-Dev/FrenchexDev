#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;

public interface IUpCommand : IAsyncCommand, IAsyncRootCommand<IUpCommandRequest, IUpCommandResponse>
{
}