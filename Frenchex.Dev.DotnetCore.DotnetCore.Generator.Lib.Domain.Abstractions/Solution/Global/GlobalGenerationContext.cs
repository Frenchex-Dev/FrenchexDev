﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

public class GlobalGenerationContext : IGlobalGenerationContext
{
    public required string Path { get; set; }
}
