﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Facade;

public interface IProvisionCommandFacade : IFacableCommand,
    IFacade<IProvisionCommand, IProvisionCommandRequestBuilderFactory, IProvisionCommandRequestBuilder>
{
}