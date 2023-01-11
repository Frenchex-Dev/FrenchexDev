#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Command;

public class InitCommand : IInitCommand
{
    public string GetCliCommandName()
    {
        return "init";
    }

    public IInitCommandResponse StartProcess(IInitCommandRequest request)
    {
        throw new NotImplementedException();
    }
}