#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

/// <summary>
/// </summary>
/// <param name="processStarterFactory"></param>
public class TemplateInstaller(
    IProcessStarterFactory processStarterFactory
) : ITemplateInstaller
{
    /// <summary>
    /// </summary>
    /// <param name="csProjPath"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="ProcessNotStartedException"></exception>
    /// <exception cref="TemplateInstallationException"></exception>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">Access to <paramref name="csProjPath" /> is denied.</exception>
    public async Task<ITemplateInstallationResult> InstallAsync(
        ICsProjPath       csProjPath
      , CancellationToken cancellationToken = default
    )
    {
        var dirPath = new FileInfo(csProjPath.Path)?.DirectoryName ?? throw new DirectoryNotFoundException(csProjPath.Path);

        var processExecution = await processStarterFactory
                                     .Factory()
                                     .StartAsync(
                                                 new ProcessExecutionContext(
                                                                             dirPath
                                                                           , "dotnet"
                                                                           , "new install ./"
                                                                           , new Dictionary<string, string>()
                                                                           , true
                                                                           , false)
                                               , cancellationToken);

        if (!processExecution.HasStarted)
            throw new ProcessNotStartedException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));

        await processExecution.WaitForExitAsync(cancellationToken);

        if (processExecution.ExitCode > 0)
            return new TemplateInstallationErrorResult
                   {
                       Error = (await processExecution.StdOutStream.ReadLineAsync(cancellationToken))!
                   };

        return new TemplateInstallationOkResult();
    }
}
