#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class ProjectTemplateDefinition : TemplateDefinition, IProjectTemplateDefinition
{
    public required ICsProj                  CsProj   { get; set; }
    public required ILicense                 License  { get; set; }
    public required IReadme                  Readme   { get; set; }
    public required IList<IPackageReference> Packages { get; set; }
}