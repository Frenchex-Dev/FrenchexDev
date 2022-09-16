namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.SshConfig;

public class SshConfigCommandIntegrationPayload : CommandIntegrationPayload
{
    public string[]? NamesOrIds { get; init; }
    public bool Plain { get; init; }
    public string? ExtraSshArgs { get; init; }
    public bool? WithColor { get; init; }
}