using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;

public interface IUpCommandRequest : IRootCommandRequest
{
    string[] NamesOrIds { get; }
    bool Provision { get; }
    string[] ProvisionWith { get; }
    bool DestroyOnError { get; }
    bool Parallel { get; }
    string Provider { get; }
    bool InstallProvider { get; }
}