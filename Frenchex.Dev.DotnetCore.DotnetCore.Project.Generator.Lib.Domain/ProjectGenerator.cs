#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain;

public class ProjectGenerator(
    IProcessStarterFactory processStarterFactory
) : IProjectGenerator
{
    /// <summary>
    /// </summary>
    /// <param name="projectDefinition"></param>
    /// <param name="generationContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ProcessNotStartedException"></exception>
    /// <exception cref="IOException">
    ///     The directory specified by <paramref name="path" /> is a file.
    ///     -or-
    ///     The network name is not known.
    /// </exception>
    public async Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition projectDefinition
      , IGenerationContext generationContext
      , CancellationToken  cancellationToken = default
    )
    {
        if (!Directory.Exists(generationContext.Path)) Directory.CreateDirectory(generationContext.Path);

        var arguments = BuildArguments(projectDefinition, generationContext);

        var processExecutionContext = await processStarterFactory
                                            .Factory()
                                            .StartAsync(
                                                        new ProcessExecutionContext(
                                                                                    generationContext.Path
                                                                                  , "dotnet"
                                                                                  , string.Join(" ", arguments)
                                                                                  , new Dictionary<string, string>()
                                                                                  , true
                                                                                  , true)
                                                      , cancellationToken);
        if (!processExecutionContext.HasStarted)
            throw new ProcessNotStartedException(await processExecutionContext.StdErrStream.ReadToEndAsync(cancellationToken));

        await processExecutionContext.WaitForExitAsync(cancellationToken);

        if (processExecutionContext.ExitCode > 0)
            return new ProjectGenerationErrorResult
                   {
                       Message = await processExecutionContext.StdErrStream.ReadToEndAsync(cancellationToken)
                   };

        return new ProjectGenerationOk();
    }

    private static List<string> BuildArguments(
        IProjectDefinition projectDefinition
      , IGenerationContext generationContext
    )
    {
        var arguments = new List<string>
                        {
                            "new"
                          , projectDefinition.TemplateName
                          , "--language"
                          , projectDefinition.Language
                          , "--output"
                          , generationContext.Path
                          , "--name"
                          , projectDefinition.Name
                        };

        if (projectDefinition.ExtraArgs.Count > 0)
            foreach (var arg in projectDefinition.ExtraArgs)
                arguments.Add($"{arg.Key} {arg.Value}");

        return arguments;
    }
}
