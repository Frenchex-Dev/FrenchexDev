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

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public interface IOsVersionArgumentBuilder
{
    Argument<string> Build();
}

public class OsVersionArgumentBuilder : IOsVersionArgumentBuilder
{
    public Argument<string> Build()
    {
        return new Argument<string>("os-version", "OS Version");
    }
}