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

public interface IOsVersionOptionBuilder
{
    Option<string> Build();
}

public class OsVersionOptionBuilder : IOsVersionOptionBuilder
{
    public Option<string> Build()
    {
        return new Option<string>("os-version", "OS Version");
    }
}