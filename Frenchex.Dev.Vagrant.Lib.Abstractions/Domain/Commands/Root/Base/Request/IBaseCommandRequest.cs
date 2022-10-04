namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequest : Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request.IBaseCommandRequest
{
    bool Color { get; }
    bool MachineReadable { get; }
    bool Version { get; }
    bool Debug { get; }
    bool Timestamp { get; }
    bool DebugTimestamp { get; }
    bool Help { get; }
}