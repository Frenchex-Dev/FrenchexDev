#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain;

public class AddProjectService(
    IProcessStarterFactory processStarterFactory
) : IAddProjectService
{
    /// <summary>
    /// </summary>
    /// <param name="solution"></param>
    /// <param name="project"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="SolutionDoesNotExistException"></exception>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">Access to <paramref name="solution" /> is denied.</exception>
    /// <exception cref="ProcessNotStartedException">Dotnet error.</exception>
    public async Task<IAddProjectResult> AddAsync(
        ISolution         solution
      , ICsProj           project
      , CancellationToken cancellationToken = default
    )
    {
        var solutionFolder = new FileInfo(solution.Path).DirectoryName ?? throw new SolutionDoesNotExistException(solution.Path);

        var args = new List<string>
                   {
                       "sln"
                     , solution.Path
                     , "add"
                   };

        if (project.HasSolutionFolder)
            args.AddRange(
                          new List<string>
                          {
                              "--solution-folder"
                            , project.SolutionFolder!
                          });

        args.Add(project.Path);

        var processExecution = await processStarterFactory
                                     .Factory()
                                     .StartAsync(
                                                 new ProcessExecutionContext(
                                                                             solutionFolder
                                                                           , "dotnet"
                                                                           , string.Join(" ", args)
                                                                           , new Dictionary<string, string>()
                                                                           , true
                                                                           , false)
                                               , cancellationToken);


        if (!processExecution.HasStarted)
            throw new ProcessNotStartedException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));

        await processExecution.WaitForExitAsync(cancellationToken);

        if (processExecution.ExitCode > 0)
            return new AddProjectErrorResult
                   {
                       Error = await processExecution.StdOutStream.ReadToEndAsync(cancellationToken)
                   };

        return new AddProjectOkResult();
    }
}
