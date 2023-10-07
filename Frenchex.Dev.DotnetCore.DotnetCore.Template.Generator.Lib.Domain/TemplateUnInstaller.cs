#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

/// <summary>
/// </summary>
/// <param name="processStarterFactory"></param>
public class TemplateUnInstaller(
    IProcessStarterFactory processStarterFactory
) : ITemplateUnInstaller
{
    /// <summary>
    /// </summary>
    /// <param name="csProjPath"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ProcessNotStartedException"></exception>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">Access to <paramref name="csProjPath" /> is denied.</exception>
    /// <exception cref="TemplateUninstallationException">Dotnet error.</exception>
    public async Task UnInstallAsync(
        ICsProjPath       csProjPath
      , CancellationToken cancellationToken = default
    )
    {
        var dirPath = new FileInfo(csProjPath.Path)?.DirectoryName ?? throw new DirectoryNotFoundException(csProjPath.Path);

        var processExecution = await processStarterFactory.Factory()
                                                          .StartAsync(
                                                                      new ProcessExecutionContext(
                                                                                                  dirPath
                                                                                                , "dotnet"
                                                                                                , "new uninstall ./"
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
            throw new TemplateUninstallationException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));
        }
    }
}