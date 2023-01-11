#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Tests;

public class InputCommand
{
    public InputCommand(
        string name,
        string command
    )
    {
        Name = name;
        Command = command;
    }

    public string Name { get; }
    public string Command { get; }
}