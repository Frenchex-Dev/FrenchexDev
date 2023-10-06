#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions
{
    public class SolutionGenerationErrorResult : ISolutionGenerationResult
    {
        public required string Error { get; set; }
    }
}
