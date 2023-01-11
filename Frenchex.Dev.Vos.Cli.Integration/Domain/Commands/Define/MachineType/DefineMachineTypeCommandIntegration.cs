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

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType;

public class DefineMachineTypeCommandIntegration : IDefineMachineTypeCommandIntegration
{
    private readonly IEnumerable<IDefineMachineTypeSubCommandIntegration> _subs;

    public DefineMachineTypeCommandIntegration(
        IEnumerable<IDefineMachineTypeSubCommandIntegration> subs
    )
    {
        _subs = subs;
    }

    public void Integrate(Command rootDefineCommand)
    {
        var command = new Command("machine-type", "Machine-type definitionDeclaration commands");

        rootDefineCommand.Add(command);

        foreach (var item in _subs) item.Integrate(command);
    }
}