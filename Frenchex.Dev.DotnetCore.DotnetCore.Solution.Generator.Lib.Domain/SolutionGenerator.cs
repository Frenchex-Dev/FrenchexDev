using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain;

public class SolutionGenerator(
    IProcessStarterFactory processStarterFactory
) : ISolutionGenerator
{
    public async Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition solution
      , CancellationToken   cancellationToken = default
    )
    {
        var dirInfo = new DirectoryInfo(solution.Path);

        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }

        var process = processStarterFactory.Factory();

        var processExecution = await process.StartAsync(new ProcessExecutionContext(solution.Path, "dotnet"
                                                                                   , $"new sln --name {solution.Name} -o {solution.Path} --force"
                                                                                   , new Dictionary<string, string>()
                                                                                   , true, true), cancellationToken);
        if (!processExecution.HasStarted)
        {
            throw new ProcessNotStartedException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));
        }

        await processExecution.WaitForExitAsync(cancellationToken);


        return new SolutionGeneratedResult();
    }
}

public class ProcessNotStartedException(
    string message
) : Exception(message);
