using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface ITimeoutMsOptionBuilder
{
    Option<string> Build();
    Option<string> Build(string defaultTimespanStr);
    Option<string> Build(string[] aliases, Func<string> getDefaultFunc, string description);
}

public class TimeoutMsOptionBuilder : ITimeoutMsOptionBuilder
{
    public Option<string> Build()
    {
        return Build(
            new[] {"--timeout", "-t"},
            () => "1s",
            "TimeOut in ms"
        );
    }

    public Option<string> Build(string defaultTimespanStr)
    {
        return Build(
            new[] {"--timeout", "-t"},
            () => defaultTimespanStr,
            "TimeOut in ms"
        );
    }

    public Option<string> Build(string[] aliases, Func<string> getDefaultFunc, string description)
    {
        return new Option<string>(
            aliases,
            getDefaultFunc,
            description
        );
    }
}