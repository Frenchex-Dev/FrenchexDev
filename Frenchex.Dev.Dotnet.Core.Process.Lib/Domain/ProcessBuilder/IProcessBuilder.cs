#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;

public interface IProcessBuilder
{
    IProcess Build(IProcessBuildingParameters parameters);
}

public interface IProcessBuildingParameters
{
    string Command { get; }
    string Arguments { get; }
    string? WorkingDirectory { get; }
    string? TimeOut { get; }
    bool UseShellExecute { get; }
    bool RedirectStandardInput { get; }
    bool RedirectStandardOutput { get; }
    bool RedirectStandardError { get; }
    bool CreateNoWindow { get; }
}

public class ProcessBuildingParameters : IProcessBuildingParameters
{
    public ProcessBuildingParameters(
        string command,
        string arguments,
        string? workingDirectory,
        string? timeout,
        bool useShellExecute,
        bool redirectStandardInput,
        bool redirectStandardOuput,
        bool redirectStandardError,
        bool createNoWindow
    )
    {
        Command = command;
        Arguments = arguments;
        WorkingDirectory = workingDirectory;
        TimeOut = timeout;
        UseShellExecute = useShellExecute;
        RedirectStandardInput = redirectStandardInput;
        RedirectStandardOutput = redirectStandardOuput;
        RedirectStandardError = redirectStandardError;
        CreateNoWindow = createNoWindow;
    }

    public string Command { get; set; }
    public string Arguments { get; set; }
    public string? WorkingDirectory { get; set; }
    public string? TimeOut { get; set; }
    public bool UseShellExecute { get; set; }
    public bool RedirectStandardInput { get; set; }
    public bool RedirectStandardOutput { get; set; }
    public bool RedirectStandardError { get; set; }
    public bool CreateNoWindow { get; set; }
}