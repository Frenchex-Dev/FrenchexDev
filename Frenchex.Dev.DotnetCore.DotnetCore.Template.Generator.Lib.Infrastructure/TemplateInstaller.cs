#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Diagnostics;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

public class TemplateInstaller : ITemplateInstaller
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="csProjPath"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="ProcessNotStartedException"></exception>
    /// <exception cref="TemplateInstallationException"></exception>
    public async Task InstallAsync(
        ICsProjPath       csProjPath
      , CancellationToken cancellationToken = default
    )
    {
        var process = new Process
                      {
                          StartInfo = new ProcessStartInfo("dotnet", "new install ./")
                                      {
                                          CreateNoWindow         = true
                                        , RedirectStandardError  = true
                                        , RedirectStandardInput  = true
                                        , RedirectStandardOutput = true
                                        , WorkingDirectory       = new FileInfo(csProjPath.Path)?.Directory?.FullName ?? throw new DirectoryNotFoundException(csProjPath.Path)
                                      }
                        , EnableRaisingEvents = true
                      };

        var started = process.Start();

        if (!started)
            throw new ProcessNotStartedException(await process.StandardError.ReadToEndAsync(cancellationToken));

        await process.WaitForExitAsync(cancellationToken);

        if (process.HasExited
         && process.ExitCode != 0)
            throw new TemplateInstallationException(await process.StandardError.ReadToEndAsync(cancellationToken));
    }
}

public class TemplateInstallationException(
    string message
) : Exception(message);
