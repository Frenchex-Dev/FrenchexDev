#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Provisioning;

public interface IDefineProvisioningSubCommandIntegration
{
    void Integrate(Command rootDefineCommand);
}