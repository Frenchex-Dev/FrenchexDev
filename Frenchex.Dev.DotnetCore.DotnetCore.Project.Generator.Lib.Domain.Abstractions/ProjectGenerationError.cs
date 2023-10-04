namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;

public class ProjectGenerationError : IProjectGenerationResult
{
    public required string Message { get; set; }
}