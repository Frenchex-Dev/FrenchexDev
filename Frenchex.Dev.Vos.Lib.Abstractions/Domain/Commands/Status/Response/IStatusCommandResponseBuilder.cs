﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.Collections.Immutable;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

public interface IStatusCommandResponseBuilder : IRootResponseBuilder
{
    IStatusCommandResponse Build();

    IStatusCommandResponseBuilder WithStatuses(
        IImmutableDictionary<string, (string, VagrantMachineStatusEnum)> statuses
    );
}