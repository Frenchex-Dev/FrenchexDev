#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

public interface IGeneratedFile
{
    string FileName  { get; }
    string Extension { get; }
    string Path      { get; }
    string Content   { get; }
}
