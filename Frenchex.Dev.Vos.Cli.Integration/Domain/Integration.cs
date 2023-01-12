#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;
using Frenchex.Dev.Vos.Cli.IntegrationLib.Domain;

#endregion

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
        var command = new Command("vos", "Vos commands");
        rootCommand.Add(command);
        IntegrateInternal(command);
    }

    public void Integrate(Command parentCommand)
    {
        IntegrateInternal(parentCommand);
    }

    private void IntegrateInternal(Command parentCommand)
    {
        foreach (var vexCommand in _vexCommands)
        {
            vexCommand.IntegrateInto(parentCommand);
        }
    }
}