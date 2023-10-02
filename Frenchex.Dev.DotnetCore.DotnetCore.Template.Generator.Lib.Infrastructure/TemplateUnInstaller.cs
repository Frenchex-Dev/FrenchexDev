using System.Diagnostics;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

public class TemplateUnInstaller : ITemplateUnInstaller
{
    public async Task UnInstallAsync(
        ICsProjPath       csProjPath
      , CancellationToken cancellationToken = default
    )
    {
        var process = new Process
                      {
                          StartInfo = new ProcessStartInfo("dotnet"
                                                         , $"new install {csProjPath.Path}")
                                      {
                                          CreateNoWindow = true
                                         ,
                                          RedirectStandardError = true
                                         ,
                                          RedirectStandardInput = true
                                         ,
                                          RedirectStandardOutput = true
                                      }
                         ,
                          EnableRaisingEvents = true
                      };

        var started = process.Start();

        if (!started)
            throw new ProcessNotStartedException(await process.StandardError.ReadToEndAsync(cancellationToken));

        await process.WaitForExitAsync(cancellationToken);
    }
}