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

public interface INameArgumentBuilder
{
    Argument<string> Build();
}

public class NameArgumentBuilder : INameArgumentBuilder

{
    public Argument<string> Build()
    {
        return new Argument<string>("name", "Name");
    }
}