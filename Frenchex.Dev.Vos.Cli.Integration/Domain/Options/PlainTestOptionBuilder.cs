using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IPlainTextOptionBuilder
{
    Option<bool> Build();
}

public class PlainTextOptionBuilder : IPlainTextOptionBuilder
{
    public Option<bool> Build()
    {
        return new Option<bool>(new[] {"--plain"}, "Plain text");
    }
}