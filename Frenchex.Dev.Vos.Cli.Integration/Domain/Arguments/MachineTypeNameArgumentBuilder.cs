using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public interface IMachineTypeNameArgumentBuilder
{
    Argument<string> Build();
}

public class MachineTypeNameArgumentBuilder : IMachineTypeNameArgumentBuilder
{
    public Argument<string> Build()
    {
        return new Argument<string>("type", "MachineType Name");
    }
}