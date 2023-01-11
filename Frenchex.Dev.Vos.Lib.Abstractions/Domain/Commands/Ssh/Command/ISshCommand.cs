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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;

public interface ISshCommand : IAsyncCommand, IAsyncRootCommand<ISshCommandRequest, ISshCommandResponse>
{
}