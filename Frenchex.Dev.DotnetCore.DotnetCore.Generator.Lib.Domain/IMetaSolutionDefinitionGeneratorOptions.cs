namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public interface IMetaSolutionDefinitionGeneratorOptions
{
    int TemplatesGenerationMaxConcurrency { get; }
    int ProjectsGenerationMaxConcurrency  { get; }
}