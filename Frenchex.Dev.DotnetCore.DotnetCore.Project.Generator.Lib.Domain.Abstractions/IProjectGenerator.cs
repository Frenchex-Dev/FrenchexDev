namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;

public interface IProjectGenerator
{
    Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition projectDefinition
      , IGenerationContext generationContext
      , CancellationToken  cancellationToken = default
    );
}