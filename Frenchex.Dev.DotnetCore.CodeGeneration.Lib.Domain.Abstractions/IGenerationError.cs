#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

public interface IGenerationError
{
    string Error    { get; }
    string Path     { get; }
    string FileName { get; }
}
