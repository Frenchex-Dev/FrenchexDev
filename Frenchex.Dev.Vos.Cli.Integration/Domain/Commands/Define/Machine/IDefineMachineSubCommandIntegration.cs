using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.Machine;

public interface IDefineMachineSubCommandIntegration
{
    void Integrate(Command rootDefineMachineCommand);
}