using System.Diagnostics;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain;

public class SolutionGenerator : ISolutionGenerator
{
    public async Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition solution
      , CancellationToken   cancellationToken = default
    )
    {
        var process = new Process
                      {
                          StartInfo = new ProcessStartInfo
                                      {
                                          FileName = "dotnet"
                                        , ArgumentList =
                                          {
                                              "new"
                                            , "sln"
                                            , "--name"
                                            , solution.Name
                                            , "-o"
                                            , solution.Path
                                            , "--force"
                                          }
                                        , WorkingDirectory       = solution.Path
                                        , RedirectStandardInput  = true
                                        , RedirectStandardOutput = true
                                        , RedirectStandardError  = true
                                        , CreateNoWindow         = true
                                      }
                      };

        var started = process.Start();

        if (!started)
            throw new ProcessNotStartedException(await process.StandardError.ReadToEndAsync(cancellationToken));

        await process.WaitForExitAsync(cancellationToken);

        return new SolutionGeneratedResult();
    }
}

public class ProcessNotStartedException(
    string message
) : Exception(message);
