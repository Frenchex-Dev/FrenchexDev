#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain
{
    /// <summary>
    /// </summary>
    /// <param name="processStarterFactory"></param>
    public class PackagesInstaller(
        IProcessStarterFactory processStarterFactory
    ) : IPackagesInstaller
    {
        /// <summary>
        /// </summary>
        /// <param name="csProjPath"></param>
        /// <param name="packages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentNullException"><see langword="null" /> was passed in for the directory name.</exception>
        /// <exception cref="UnauthorizedAccessException">Access to <paramref name="csProjPath" /> is denied.</exception>
        /// <exception cref="ProcessNotStartedException">Dotnet error.</exception>
        /// <exception cref="PackageInstallationException">Dotnet error.</exception>
        public async Task InstallAsync(
            ICsProjPath              csProjPath
          , IList<IPackageReference> packages
          , CancellationToken        cancellationToken = default
        )
        {
            var dirPath = new FileInfo(csProjPath.Path)?.DirectoryName ?? throw new DirectoryNotFoundException(csProjPath.Path);

            foreach (var package in packages)
            {
                var processExecution = await processStarterFactory.Factory()
                                                                  .StartAsync(
                                                                              new ProcessExecutionContext(
                                                                                                          dirPath
                                                                                                        , "dotnet"
                                                                                                        , $"add {csProjPath.Path} package {package.Name} --version {package.Version}"
                                                                                                        , new Dictionary<string,
                                                                                                              string>()
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
                    throw new PackageInstallationException(await processExecution.StdErrStream.ReadToEndAsync(cancellationToken));
                }
            }
        }
    }
}
