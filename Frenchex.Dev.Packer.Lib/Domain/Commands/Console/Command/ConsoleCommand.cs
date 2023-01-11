#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Command;

public class ConsoleCommand : IConsoleCommand
{
    public string GetCliCommandName()
    {
        return "console";
    }

    public IConsoleCommandResponse StartProcess(IConsoleCommandRequest request)
    {
        throw new NotImplementedException();
    }
}