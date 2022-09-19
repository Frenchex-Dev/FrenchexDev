using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Request;

public class ProvisionCommandRequest : IProvisionCommandRequest
{
    public IBaseCommandRequest Base { get; set; }
    public string? VmName { get; }
    public string[]? ProvisionWith { get; set; }
}