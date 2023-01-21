#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface ICommandsOptionBuilder
{
    Option<string[]> Build();
}

public class CommandsOptionBuilder : ICommandsOptionBuilder
{
    public Option<string[]> Build()
    {
        return new Option<string[]>("--command", "Command");
    }
}