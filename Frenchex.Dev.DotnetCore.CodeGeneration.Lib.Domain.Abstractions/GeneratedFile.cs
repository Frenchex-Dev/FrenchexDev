#region Licensing

// Licensing please read LICENSE.md

#endregion


namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

public class GeneratedFile : IGeneratedFile
{
    public required string FileName { get; set; }
    public required string Extension { get; set; }
    public required string Path { get; set; }
    public required string Content { get; set; }
}