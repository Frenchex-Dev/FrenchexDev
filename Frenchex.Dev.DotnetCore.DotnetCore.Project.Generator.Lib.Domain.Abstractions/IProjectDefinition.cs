#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;

public interface IProjectDefinition
{
    string                     Name               { get; }
    string                     Language           { get; }
    string                     TemplateName       { get; }
    Dictionary<string, string> ExtraArgs          { get; }
    List<IProjectReference>    ProjectsReferences { get; set; }
}
