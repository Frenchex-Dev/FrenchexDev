#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain;

public class AddPackageService(
    IProcessStarterFactory processStarterFactory
) : IAddPackageService
{
    /// <summary>
    /// </summary>
    /// <param name="project"></param>
    /// <param name="package"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">Access to <paramref name="project" /> is denied.</exception>
    /// <exception cref="ProcessNotStartedException">Dotnet error.</exception>
    public async Task<IAddPackageResult> AddAsync(
        ICsProj            project
      , IPackageDefinition package
      , CancellationToken  cancellationToken = default
    )
    {
        var csProjFileInfo = new FileInfo(project.Path);
        if (!csProjFileInfo.Exists)
            return new AddPackageErrorResult
                   {
                       Error = "Project does not exist"
                   };

        var dirPath = csProjFileInfo.DirectoryName!;

        var processExecution = await processStarterFactory
                                     .Factory()
                                     .StartAsync(
                                                 new ProcessExecutionContext(
                                                                             dirPath
                                                                           , "dotnet"
                                                                           , $"add {project.Path} package {package.Name} --version {package.Version}"
                                                                           , new Dictionary<string, string>()
                                                                           , true
                                                                           , true)
                                               , cancellationToken);

        if (!processExecution.HasStarted)
            throw new ProcessNotStartedException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));

        await processExecution.WaitForExitAsync(cancellationToken);

        if (processExecution.ExitCode > 0)
            return new AddPackageErrorResult
                   {
                       Error = await processExecution.StdErrStream.ReadToEndAsync(cancellationToken)
                   };

        return new AddPackageOkResult();
    }
}
