#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

public interface IGeneratedCodeWriterOptions
{
    int WriteFilesMaxConcurrency { get; }
}
