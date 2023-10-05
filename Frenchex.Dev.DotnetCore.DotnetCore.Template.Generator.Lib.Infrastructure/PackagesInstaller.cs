#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Diagnostics;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

public class PackagesInstaller : IPackagesInstaller
{
    public async Task InstallAsync(
        ICsProjPath              csProjPath
      , IList<IPackageReference> packages
      , CancellationToken        cancellationToken = default
    )
    {
        foreach (var package in packages)
        {
            var process = new Process
                          {
                              StartInfo = new ProcessStartInfo("dotnet"
                                                             , $"add {csProjPath.Path} package {package.Name} --version {package.Version}")
                                          {
                                              CreateNoWindow         = true
                                            , RedirectStandardError  = true
                                            , RedirectStandardInput  = true
                                            , RedirectStandardOutput = true
                                          }
                            , EnableRaisingEvents = true
                          };

            var started = process.Start();

            if (!started)
                throw new ProcessNotStartedException(await process.StandardError.ReadToEndAsync(cancellationToken));

            await process.WaitForExitAsync(cancellationToken);
        }
    }
}
