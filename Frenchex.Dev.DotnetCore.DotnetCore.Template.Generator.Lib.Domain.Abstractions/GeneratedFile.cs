namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class GeneratedFile : IGeneratedFile
{
    public required string FileName  { get; set; }
    public required string Extension { get; set; }
    public required string Path      { get; set; }
    public required string Content   { get; set; }
}
