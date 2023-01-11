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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;

public interface IStatusCommand : IAsyncCommand, IAsyncRootCommand<IStatusCommandRequest, IStatusCommandResponse>
{
}