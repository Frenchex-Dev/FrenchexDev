#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public interface IMetaSolutionDefinitionGeneratorOptions
{
    int TemplatesGenerationMaxConcurrency { get; }
    int ProjectsGenerationMaxConcurrency  { get; }
}
