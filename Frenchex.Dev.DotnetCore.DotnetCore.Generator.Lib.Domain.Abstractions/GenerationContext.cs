﻿namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class GenerationContext : IGenerationContext
{
    public required string Path { get; set; }
}