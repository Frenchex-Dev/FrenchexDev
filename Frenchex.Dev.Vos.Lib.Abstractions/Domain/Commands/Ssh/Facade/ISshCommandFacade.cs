#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Facade;

public interface ISshCommandFacade : IFacableCommand,
    IFacade<ISshCommand, ISshCommandRequestBuilderFactory, ISshCommandRequestBuilder>
{
}