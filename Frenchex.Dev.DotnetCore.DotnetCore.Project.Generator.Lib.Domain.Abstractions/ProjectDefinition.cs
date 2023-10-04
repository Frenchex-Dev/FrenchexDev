namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;

public class ProjectDefinition : IProjectDefinition
{
    public required string                     Name               { get; set; }
    public required string                     Language           { get; set; }
    public required string                     TemplateName       { get; set; }
    public required Dictionary<string, string> ExtraArgs          { get; set; }
    public required List<IProjectReference>    ProjectsReferences { get; set; }
}