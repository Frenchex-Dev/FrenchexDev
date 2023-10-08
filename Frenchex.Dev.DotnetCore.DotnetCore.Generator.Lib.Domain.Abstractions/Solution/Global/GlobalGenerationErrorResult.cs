#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

public class GlobalGenerationErrorResult : IGlobalGenerationResult
{
    public required string     Error     { get; set; }
    public          Exception? Exception { get; set; }
}
