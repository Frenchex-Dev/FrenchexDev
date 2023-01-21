#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public class CommandRequestHolder : IBaseCommandRequest
{
    public CommandRequestHolder(
        string? workingDirectory,
        bool? tty,
        string? timeout,
        string? binPath
    )
    {
        WorkingDirectory = workingDirectory;
        BinPath = binPath;
        Timeout = timeout;
        Tty = tty ?? false;
    }

    public bool Tty { get; }
    public string? WorkingDirectory { get; }
    public string? BinPath { get; }
    public string? Timeout { get; }
}