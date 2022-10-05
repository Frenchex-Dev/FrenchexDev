namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Command.Generator;

public class CommandGeneratorRequest
{
    public CommandGeneratorRequest(
        string ns,
        string basePath,
        bool withCommand,
        bool withFacade,
        bool withRequest,
        bool withResponse,
        bool withDependencyInjection
    )
    {
        Namespace = ns;
        BasePath = basePath;
        WithCommand = withCommand;
        WithFacade = withFacade;
        WithRequest = withRequest;
        WithResponse = withResponse;
        WithDependencyInjection = withDependencyInjection;
    }

    public string Namespace { get; }
    public string BasePath { get; }
    public bool WithCommand { get; }
    public bool WithFacade { get; }
    public bool WithRequest { get; }
    public bool WithResponse { get; }
    public bool WithDependencyInjection { get; }
}