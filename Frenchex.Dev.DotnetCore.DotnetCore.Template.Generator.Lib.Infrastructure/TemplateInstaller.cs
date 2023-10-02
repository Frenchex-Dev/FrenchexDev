using System.Diagnostics;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

public class TemplateInstaller : ITemplateInstaller
{
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
                                        , WorkingDirectory       = new FileInfo(csProjPath.Path).Directory.FullName
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

public class TemplateInstallationException : Exception
{
    public TemplateInstallationException(
        string message
    ) : base(message)
    {
    }
}
