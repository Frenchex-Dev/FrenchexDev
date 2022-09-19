using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;

public interface IProvisionCommandRequest : IRootCommandRequest
{
    string? VmName { get; }
    string[]? ProvisionWith { get; }
}