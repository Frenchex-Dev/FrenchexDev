#region Licensing

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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponse : IStatusCommandResponse
{
    public StatusCommandResponse(
        IImmutableDictionary<string, (string, VagrantMachineStatusEnum)> statuses
    )
    {
        Statuses = statuses;
    }

    public IImmutableDictionary<string, (string, VagrantMachineStatusEnum)> Statuses { get; }
}