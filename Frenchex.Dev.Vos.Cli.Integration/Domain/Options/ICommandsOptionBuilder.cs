using System.CommandLine;

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