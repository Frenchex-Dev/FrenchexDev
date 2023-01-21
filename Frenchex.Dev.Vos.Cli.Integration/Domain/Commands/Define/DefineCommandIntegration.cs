#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define;

public class DefineCommandIntegration : IDefineCommandIntegration
{
    private readonly IEnumerable<IDefineSubCommandIntegration> _defineSubCommandIntegrations;

    public DefineCommandIntegration(
        IEnumerable<IDefineSubCommandIntegration> subDefineCommandsIntegrations
    )
    {
        _defineSubCommandIntegrations = subDefineCommandsIntegrations;
    }

    public void IntegrateInto(Command parentCommand)
    {
        var rootDefineCommand = new Command("define", "Defining configuration");

        parentCommand.Add(rootDefineCommand);

        foreach (IDefineSubCommandIntegration? item in _defineSubCommandIntegrations) item.Integrate(rootDefineCommand);
    }
}