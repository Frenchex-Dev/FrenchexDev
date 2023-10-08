#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;

public class ProjectDefintion : IProjectDefinition
{
    public required ICsProj                          CsProj                     { get; set; }
    public required IList<IProjectReference>         ProjectsReferences         { get; set; }
    public required IList<IExternalProjectReference> ExternalProjectsReferences { get; set; }
    public required IList<IPackageReference>         PackagesReferences         { get; set; }
    public required string                           Template                   { get; set; }
    public required IDictionary<string, string>      TemplateArgs               { get; set; }
}
