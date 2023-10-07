#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class GenerationError : IGenerationError
{
    public required string Error    { get; set; }
    public required string Path     { get; set; }
    public required string FileName { get; set; }
}