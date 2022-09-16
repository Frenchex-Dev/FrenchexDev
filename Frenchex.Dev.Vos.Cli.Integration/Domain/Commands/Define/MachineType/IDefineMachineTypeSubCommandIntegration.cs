using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Define.MachineType;

public interface IDefineMachineTypeSubCommandIntegration
{
    void Integrate(Command rootDefineMachineCommand);
}