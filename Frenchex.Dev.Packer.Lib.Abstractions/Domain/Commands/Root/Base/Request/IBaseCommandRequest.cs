#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequest : Dotnet.Wrapping.Lib.Domain.Commands.Root.IBaseCommandRequest
{
    bool Color { get; }
    bool MachineReadable { get; }
    bool Version { get; }
    bool Debug { get; }
    bool Timestamp { get; }
    bool DebugTimestamp { get; }
    bool Help { get; }
}