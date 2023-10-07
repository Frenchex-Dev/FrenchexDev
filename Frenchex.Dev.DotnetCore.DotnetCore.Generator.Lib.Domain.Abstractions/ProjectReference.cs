#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class ProjectReference : IProjectReference
{
    public required ICsProj ReferencedProject { get; set; }
}
