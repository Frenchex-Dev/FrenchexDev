#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

public interface IProcess : IDisposable
{
    public System.Diagnostics.Process WrappedProcess { get; }
    ProcessExecutionResult Start();
    void Stop();
    bool HasStarted();
}