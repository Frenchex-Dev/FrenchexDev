using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define;

public class DefineCommandIntegration : IDefineCommandIntegration
{
    private readonly IEnumerable<IDefineSubCommandIntegration> _defineSubCommandIntegrations;

    public DefineCommandIntegration(
        IEnumerable<IDefineSubCommandIntegration> subDefineCommandsIntegrations
    )
    {
        _defineSubCommandIntegrations = subDefineCommandsIntegrations;
    }

    public void Integrate(Command parentCommand)
    {
        var rootDefineCommand = new Command("define", "Defining configuration");

        parentCommand.Add(rootDefineCommand);

        foreach (var item in _defineSubCommandIntegrations)
        {
            item.Integrate(rootDefineCommand);
        }
    }
}