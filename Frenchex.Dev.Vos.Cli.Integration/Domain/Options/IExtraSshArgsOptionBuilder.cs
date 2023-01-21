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

public interface IExtraSshArgsOptionBuilder
{
    Option<string> Build();
}

public class ExtraSshArgsOptionBuilder : IExtraSshArgsOptionBuilder
{
    public Option<string> Build()
    {
        return new Option<string>(
            new[] { "--extra-ssh-args" },
            () => string.Empty,
            "Extra SSH args"
        );
    }
}