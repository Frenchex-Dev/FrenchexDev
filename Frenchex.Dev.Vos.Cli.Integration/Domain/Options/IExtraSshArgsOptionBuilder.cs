using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IExtraSshArgsOptionBuilder
{
    Option<string> Build();
}

public class ExtraSshArgsOptionBuilder : IExtraSshArgsOptionBuilder
{
    public Option<string> Build()
    {
        return new Option<string>(
            new[] {"--extra-ssh-args"},
            () => string.Empty,
            "Extra SSH args"
        );
    }
}