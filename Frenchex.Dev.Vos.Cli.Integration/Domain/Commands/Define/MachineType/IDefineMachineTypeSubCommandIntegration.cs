#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType;

public interface IDefineMachineTypeSubCommandIntegration
{
    void Integrate(Command rootDefineMachineCommand);
}