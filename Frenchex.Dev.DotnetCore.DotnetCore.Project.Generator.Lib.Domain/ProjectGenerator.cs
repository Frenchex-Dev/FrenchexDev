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
    public async Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition projectDefinition
      , IGenerationContext generationContext
      , CancellationToken  cancellationToken = default
    )
    {
        if (!Directory.Exists(generationContext.Path))
        {
            Directory.CreateDirectory(generationContext.Path);
        }

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

        var processExecutionContext = await processStarterFactory.Factory()
                                                                 .StartAsync(
                                                                             new ProcessExecutionContext(
                                                                                                         generationContext.Path
                                                                                                       , "dotnet"
                                                                                                       , string.Join(" ", arguments)
                                                                                                       , new Dictionary<string,
                                                                                                             string>()
                                                                                                       , true
                                                                                                       , true)
                                                                           , cancellationToken);
        if (!processExecutionContext.HasStarted)
        {
            throw new ProcessNotStartedException(await processExecutionContext.StdErrStream.ReadToEndAsync(cancellationToken));
        }

        await processExecutionContext.WaitForExitAsync(cancellationToken);

        if (processExecutionContext.ExitCode > 0)
        {
            return new ProjectGenerationError
                   {
                       Message = await processExecutionContext.StdErrStream.ReadToEndAsync(cancellationToken)
                   };
        }

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