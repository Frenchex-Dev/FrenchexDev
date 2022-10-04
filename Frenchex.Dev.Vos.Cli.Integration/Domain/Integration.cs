using System.CommandLine;
using Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.Domain;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain;

public class Integration : IIntegration
{
    private readonly IEnumerable<IVosCommandIntegration> _vexCommands;

    public Integration(IEnumerable<IVosCommandIntegration> vexCommands)
    {
        _vexCommands = vexCommands;
    }

    public void Integrate(RootCommand rootCommand)
    {
        IntegrateInternal(rootCommand);
    }

    private void IntegrateInternal(Command parentCommand)
    {
        foreach (var vexCommand in _vexCommands)
        {
            vexCommand.IntegrateInto(parentCommand);
        }
    }

    public void Integrate(Command parentCommand)
    {
        var command = new Command("vos", "Vos commands");
        parentCommand.Add(command);

        IntegrateInternal(command);
    }
}