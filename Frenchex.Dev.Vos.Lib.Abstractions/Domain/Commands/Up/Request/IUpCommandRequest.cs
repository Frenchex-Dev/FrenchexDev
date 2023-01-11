#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;

public interface IUpCommandRequest : IRootCommandRequest
{
    string[] Names { get; }
    bool Provision { get; }
    string[] ProvisionWith { get; }
    bool DestroyOnError { get; }
    bool Parallel { get; }
    string Provider { get; }
    bool InstallProvider { get; }
    int ParallelWorkers { get; }
    int ParallelWait { get; }

    IUpCommandRequest CloneWithNewNames(string[] names);
}