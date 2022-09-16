namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Destroy;

public class DestroyCommandIntegrationPayload : CommandIntegrationPayload
{
    public string[]? NameOrId { get; set; }
    public bool Force { get; set; }
    public bool Graceful { get; set; }
    public bool Parallel { get; set; }
}