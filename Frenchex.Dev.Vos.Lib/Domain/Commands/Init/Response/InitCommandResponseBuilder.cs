#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Response;

public class InitCommandResponseBuilder : RootResponseBuilder, IInitCommandResponseBuilder
{
    public IInitCommandResponse Build()
    {
        return new InitCommandResponse();
    }
}