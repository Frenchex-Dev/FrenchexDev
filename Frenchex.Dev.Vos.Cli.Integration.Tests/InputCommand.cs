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