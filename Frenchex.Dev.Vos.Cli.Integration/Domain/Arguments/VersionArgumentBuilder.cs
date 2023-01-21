#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public interface IVersionArgumentBuilder
{
    Argument<string> Build();
}

public class VersionArgumentBuilder : IVersionArgumentBuilder
{
    public Argument<string> Build()
    {
        return new Argument<string>("version", "Provision version");
    }
}