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

public interface IParallelWaitOptionBuilder
{
    Option<int> Build();
}

public class ParallelWaitOptionBuilder : IParallelWaitOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(new[] { "--parallel-wait", "-a" },
            () => Environment.ProcessorCount,
            "Parallel Wait");
    }
}