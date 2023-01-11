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

public interface IParallelWorkersOptionBuilder
{
    Option<int> Build();
}

public class ParallelWorkersOptionBuilder : IParallelWorkersOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(new[] { "--parallel-workers", "-pw" },
            () => Environment.ProcessorCount,
            "Parallel Workers");
    }
}