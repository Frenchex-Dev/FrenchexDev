
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

public interface IBuildCommandRequest : IRootCommandRequest
{
    string Template { get; }
    bool? Color { get; }
    bool? Debug { get; }
    string[]? Except { get; }
    string[]? Only { get; }
    bool? Force { get; }
    bool? MachineReadable { get; }
    OnErrorEnum? OnError { get; }
    int? ParallelBuilds { get; }
    bool? TimestampUi { get; }
    string[]? Vars { get; }
    string? VarFilePath { get; }
}

public enum OnErrorEnum
{
    Cleanup,
    Abort,
    Ask,
    RunCleanupProvisioner
}