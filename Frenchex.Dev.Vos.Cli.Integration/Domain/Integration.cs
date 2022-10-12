using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;
using Frenchex.Dev.Vos.Cli.IntegrationLib.Domain;

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

    public void Integrate(Command parentCommand)
    {
        var command = new Command("vos", "Vos commands");
        parentCommand.Add(command);

        IntegrateInternal(command);
    }

    private void IntegrateInternal(Command parentCommand)
    {
        foreach (var vexCommand in _vexCommands)
        {
            vexCommand.IntegrateInto(parentCommand);
        }
    }
}