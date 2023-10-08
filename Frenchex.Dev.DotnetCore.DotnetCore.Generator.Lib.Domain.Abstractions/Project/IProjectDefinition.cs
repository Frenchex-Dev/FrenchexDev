#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;

public interface IProjectDefinition
{
    ICsProj                          CsProj                     { get; }
    IList<IProjectReference>         ProjectsReferences         { get; }
    IList<IExternalProjectReference> ExternalProjectsReferences { get; }
    IList<IPackageReference>         PackagesReferences         { get; }
    string                           Template                   { get; }
    IDictionary<string, string>      TemplateArgs               { get; }
}
