using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public interface IBoxNameArgumentBuilder
{
    Argument<string> Build();
}

public class BoxNameArgumentBuilder : IBoxNameArgumentBuilder
{
    public Argument<string> Build()
    {
        return new Argument<string>("box-name", "Box Name");
    }
}