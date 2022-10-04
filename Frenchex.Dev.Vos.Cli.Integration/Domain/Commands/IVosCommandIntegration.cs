using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands;

public interface IVosCommandIntegration
{
    void IntegrateInto(Command parentCommand);
}