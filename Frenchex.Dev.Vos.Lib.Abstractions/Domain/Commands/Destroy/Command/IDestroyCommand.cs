#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;

public interface IDestroyCommand : IAsyncCommand, IAsyncRootCommand<IDestroyCommandRequest, IDestroyCommandResponse>
{
}