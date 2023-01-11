#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;

public interface INameCommand : IAsyncCommand, IAsyncRootCommand<INameCommandRequest, INameCommandResponse>
{
}