#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain;

/// <summary>
/// </summary>
/// <param name="processStarterFactory"></param>
public class SolutionGenerator(
    IProcessStarterFactory processStarterFactory
) : ISolutionGenerator
{
    /// <summary>
    /// </summary>
    /// <param name="solution"></param>
    /// <param name="solutionGenerationContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ProcessNotStartedException"></exception>
    /// <exception cref="IOException">The directory cannot be created.</exception>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    public async Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition        solution
      , ISolutionGenerationContext solutionGenerationContext
      , CancellationToken          cancellationToken = default
    )
    {
        var dirInfo = new DirectoryInfo(solutionGenerationContext.Path);

        if (!dirInfo.Exists) dirInfo.Create();

        var process = processStarterFactory.Factory();

        var processExecution = await process.StartAsync(
                                                        new ProcessExecutionContext(
                                                                                    solutionGenerationContext.Path
                                                                                  , "dotnet"
                                                                                  , $"new sln --name {solution.Name} -o {solutionGenerationContext.Path} --force"
                                                                                  , new Dictionary<string, string>()
                                                                                  , true
                                                                                  , false)
                                                      , cancellationToken);
        if (!processExecution.HasStarted)
            throw new ProcessNotStartedException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));

        await processExecution.WaitForExitAsync(cancellationToken);

        if (processExecution.ExitCode > 0)
            return new SolutionGenerationErrorResult
                   {
                       Error = await processExecution.StdErrStream.ReadToEndAsync(cancellationToken)
                   };

        return new SolutionGenerationOkResult();
    }
}

public class ProcessNotStartedException(
    string message
) : Exception(message);
