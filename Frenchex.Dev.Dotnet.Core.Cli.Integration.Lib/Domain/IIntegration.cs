using System.CommandLine;

namespace Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.Domain;

public interface IIntegration
{
    void Integrate(RootCommand rootCommand);
    void Integrate(Command parentCommand);
}