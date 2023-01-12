#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.CommandLine;

#endregion

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
            new[] { "--timeout", "-t" },
            () => "1s",
            "timeout"
        );
    }

    public Option<string> Build(string defaultTimespanStr)
    {
        return Build(
            new[] { "--timeout", "-t" },
            () => defaultTimespanStr,
            "timeout"
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