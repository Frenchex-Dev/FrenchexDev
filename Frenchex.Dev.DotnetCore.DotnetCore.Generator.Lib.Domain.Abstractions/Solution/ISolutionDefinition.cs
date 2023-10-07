#region Licensing

// Licensing please read LICENSE.md

#endregion

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;

public interface ISolutionDefinition
{
    string Name { get; }

    IGlobal Gobal { get; }
}
