#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain
{
    public class SolutionGenerator(
        IProcessStarterFactory processStarterFactory
    ) : ISolutionGenerator
    {
        public async Task<ISolutionGenerationResult> GenerateAsync(
            ISolutionDefinition solution
          , IGenerationContext  generationContext
          , CancellationToken   cancellationToken = default
        )
        {
            var dirInfo = new DirectoryInfo(generationContext.Path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            var process = processStarterFactory.Factory();

            var processExecution = await process.StartAsync(
                                                            new ProcessExecutionContext(
                                                                                        generationContext.Path
                                                                                      , "dotnet"
                                                                                      , $"new sln --name {solution.Name} -o {generationContext.Path} --force"
                                                                                      , new Dictionary<string, string>()
                                                                                      , true
                                                                                      , true)
                                                          , cancellationToken);
            if (!processExecution.HasStarted)
            {
                throw new ProcessNotStartedException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));
            }

            await processExecution.WaitForExitAsync(cancellationToken);

            if (processExecution.ExitCode > 0)
            {
                return new SolutionGenerationErrorResult
                       {
                           Error = await processExecution.StdErrStream.ReadToEndAsync(cancellationToken)
                       };
            }

            return new SolutionGenerationOkResult();
        }
    }

    public class ProcessNotStartedException(
        string message
    ) : Exception(message);
}
