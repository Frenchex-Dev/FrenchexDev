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

public interface IZeroesOptionBuilder
{
    Option<int> Build();
}

public class ZeroesOptionBuilder : IZeroesOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(
            new[] { "--zeroes", "-z" },
            () => 2,
            "Numbering leading zeroes"
        );
    }
}