#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Command;

public class FixCommand : IFixCommand
{
    public string GetCliCommandName()
    {
        return "fix";
    }

    public IFixCommandResponse StartProcess(IFixCommandRequest request)
    {
        throw new NotImplementedException();
    }
}