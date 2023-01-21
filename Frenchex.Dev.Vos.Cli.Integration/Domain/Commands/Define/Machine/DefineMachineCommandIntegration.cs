#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine;

public class DefineMachineCommandIntegration : IDefineMachineCommandIntegration
{
    private readonly IEnumerable<IDefineMachineSubCommandIntegration> _subs;

    public DefineMachineCommandIntegration(
        IEnumerable<IDefineMachineSubCommandIntegration> subs
    )
    {
        _subs = subs;
    }

    public void Integrate(Command rootDefineCommand)
    {
        var command = new Command("machine", "Machine definitionDeclaration commands");

        rootDefineCommand.Add(command);

        foreach (IDefineMachineSubCommandIntegration? item in _subs) item.Integrate(command);
    }
}