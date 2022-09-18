using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequest : IRootCommandRequest
{
    string? BoxName { get; }
    string? BoxVersion { get; }
    bool? Force { get; }
    bool? Minimal { get; }
    string? OutputToFile { get; }
    string? TemplateFile { get; }
}