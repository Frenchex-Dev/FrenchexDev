#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Diagnostics;
using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Infrastructure;

public class ProjectGenerator : IProjectGenerator
{
    public async Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition projectDefinition
      , IGenerationContext generationContext
      , CancellationToken  cancellationToken = default
    )
    {
        if (!Directory.Exists(generationContext.Path)) Directory.CreateDirectory(generationContext.Path);

        var arguments = new List<string>
                        {
                            "new"
                          , projectDefinition.TemplateName
                          , projectDefinition.Language
                          , generationContext.Path
                          , projectDefinition.Name
                        };

        var process = new Process
                      {
                          StartInfo = new ProcessStartInfo
                                      {
                                          FileName               = "dotnet"
                                        , Arguments              = string.Join(" ", arguments)
                                        , WorkingDirectory       = generationContext.Path
                                        , RedirectStandardInput  = true
                                        , RedirectStandardOutput = true
                                        , RedirectStandardError  = true
                                        , CreateNoWindow         = true
                                      }
                      };

        var started = process.Start();


        if (!started)
            throw new ProcessNotStartedException(await process.StandardError.ReadToEndAsync(cancellationToken));

        await process.WaitForExitAsync(cancellationToken);

        return new ProjectGenerationOk();
    }
}

public class ProcessNotStartedException : Exception
{
    public ProcessNotStartedException(
        string message
    ) : base(message)
    {
    }
}
