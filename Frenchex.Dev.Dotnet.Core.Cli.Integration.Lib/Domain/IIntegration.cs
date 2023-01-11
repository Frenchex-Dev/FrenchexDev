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

namespace Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.Domain;

public interface IIntegration
{
    void Integrate(RootCommand rootCommand);
    void Integrate(Command parentCommand);
}