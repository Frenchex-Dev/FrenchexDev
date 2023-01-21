#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Response;

public class HaltCommandResponseBuilderFactory : RootResponseBuilderFactory, IHaltCommandResponseBuilderFactory
{
    public IHaltCommandResponseBuilder Factory()
    {
        return new HaltCommandResponseBuilder();
    }
}