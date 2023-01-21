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

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning;

public class DefineProvisioningCommandIntegration : IDefineProvisioningCommandIntegration
{
    private readonly IEnumerable<IDefineProvisioningSubCommandIntegration> _subs;

    public DefineProvisioningCommandIntegration(
        IEnumerable<IDefineProvisioningSubCommandIntegration> subDefineCommandsIntegrations
    )
    {
        _subs = subDefineCommandsIntegrations;
    }

    public void Integrate(Command parentCommand)
    {
        var rootDefineCommand = new Command("provisioning", "Defining provisioning");

        parentCommand.Add(rootDefineCommand);

        foreach (var item in _subs) item.Integrate(rootDefineCommand);
    }
}