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

public interface IParallelOptionBuilder
{
    Option<bool> Build();
}

internal class ParallelOptionBuilder : IParallelOptionBuilder
{
    public Option<bool> Build()
    {
        return new Option<bool>(new[] { "--parallel", "-p" }, () => true, "Parallel");
    }
}