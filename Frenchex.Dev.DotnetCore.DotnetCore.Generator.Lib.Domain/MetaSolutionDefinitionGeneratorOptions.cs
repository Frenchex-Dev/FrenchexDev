namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public class MetaSolutionDefinitionGeneratorOptions : IMetaSolutionDefinitionGeneratorOptions
{
    public required int TemplatesGenerationMaxConcurrency { get; set; }
    public required int ProjectsGenerationMaxConcurrency  { get; set; }
}