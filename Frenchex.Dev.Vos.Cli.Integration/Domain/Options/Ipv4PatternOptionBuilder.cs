#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IIpv4PatternOptionBuilder
{
    Option<string> Build();
}

public class Ipv4PatternOptionBuilder : IIpv4PatternOptionBuilder
{
    public Option<string> Build()
    {
        return new Option<string>(
            new[] { "--ipv4-pattern" },
            () => "10.100.1.#INSTANCE#",
            "IPv4 pattern"
        );
    }
}