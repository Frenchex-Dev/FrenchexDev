﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;

public interface ISolutionDefinition
{
    string Name { get; }
    string Path { get; }
}
