#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponseBuilderFactory : IStatusCommandResponseBuilderFactory
{
    public IStatusCommandResponseBuilder Factory()
    {
        return new StatusCommandResponseBuilder();
    }
}