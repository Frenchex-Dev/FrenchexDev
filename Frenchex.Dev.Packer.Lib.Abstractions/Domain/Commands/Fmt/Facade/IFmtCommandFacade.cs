#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Facade;

public interface IFmtCommandFacade : IFacableCommand,
    IFacade<IFmtCommand, IFmtCommandRequestBuilderFactory, IFmtCommandRequestBuilder>
{
}