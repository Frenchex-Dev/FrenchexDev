#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain;

/// <summary>
/// </summary>
/// <param name="processStarterFactory"></param>
public class AddProjectReferenceService(
    IProcessStarterFactory processStarterFactory
) : IAddProjectReferenceService
{
    /// <summary>
    /// </summary>
    /// <param name="targetProject"></param>
    /// <param name="sourceProject"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ProcessNotStartedException"></exception>
    public async Task<IAddProjectReferenceResult> AddAsync(
        ICsProj           targetProject
      , ICsProj           sourceProject
      , CancellationToken cancellationToken = default
    )
    {
        var processExecution = await processStarterFactory
                                     .Factory()
                                     .StartAsync(
                                                 new ProcessExecutionContext(
                                                                             Directory.GetCurrentDirectory()
                                                                           , "dotnet"
                                                                           , $"add {sourceProject.Path} reference {targetProject.Path}"
                                                                           , new Dictionary<string, string>()
                                                                           , true
                                                                           , false)
                                               , cancellationToken);

        if (!processExecution.HasStarted)
            throw new ProcessNotStartedException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));

        await processExecution.WaitForExitAsync(cancellationToken);

        if (processExecution.ExitCode > 0)
            return new AddProjectReferenceErrorResult
                   {
                       Error = await processExecution.StdOutStream.ReadToEndAsync(cancellationToken)
                   };

        return new AddProjectReferenceOkResult();
    }
}
