﻿namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class GenerationContext : IGenerationContext
{
    public required string Path { get; set; }
}
