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

public interface IPlainTextOptionBuilder
{
    Option<bool> Build();
}

public class PlainTextOptionBuilder : IPlainTextOptionBuilder
{
    public Option<bool> Build()
    {
        return new Option<bool>(new[] { "--plain" }, "Plain text");
    }
}