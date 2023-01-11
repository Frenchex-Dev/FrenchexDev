#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Request;

public class StatusCommandRequest : IStatusCommandRequest
{
    public StatusCommandRequest(IBaseCommandRequest baseCommand, string[] namesOrIds)
    {
        BaseCommand = baseCommand;
        Names = namesOrIds;
    }

    public IBaseCommandRequest BaseCommand { get; }

    public string[] Names { get; }
}