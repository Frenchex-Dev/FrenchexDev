using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public interface IRamMbArgumentBuilder
{
    Argument<int> Build();
}

public class RamMbArgumentBuilder : IRamMbArgumentBuilder
{
    public Argument<int> Build()
    {
        return new Argument<int>("ram-mb", "RAM in MB");
    }
}