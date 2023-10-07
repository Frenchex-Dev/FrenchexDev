#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface IProjectTemplateDefinition : ITemplateDefinition
{
    ICsProj                  CsProj   { get; }
    ILicense                 License  { get; }
    IReadme                  Readme   { get; }
    IList<IPackageReference> Packages { get; }
}
