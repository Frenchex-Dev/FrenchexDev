using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IParallelWorkersOptionBuilder
{
    Option<int> Build();
}

public class ParallelWorkersOptionBuilder : IParallelWorkersOptionBuilder
{
    public Option<int> Build()
    {
        return new Option<int>(new[] {"--parallel-workers", "-pw"},
            () => Environment.ProcessorCount,
            "Parallel Workers");
    }
}