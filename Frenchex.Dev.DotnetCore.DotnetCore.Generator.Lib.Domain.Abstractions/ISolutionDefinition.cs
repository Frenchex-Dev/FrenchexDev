#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface ISolutionDefinition
{
    string Name { get; }

    IGlobal Gobal { get; }
}
