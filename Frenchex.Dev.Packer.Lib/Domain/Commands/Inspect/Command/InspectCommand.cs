#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Command;

public class InspectCommand : IInspectCommand
{
    public string GetCliCommandName()
    {
        return "inspect";
    }


    public IInspectCommandResponse StartProcess(IInspectCommandRequest request)
    {
        throw new NotImplementedException();
    }
}