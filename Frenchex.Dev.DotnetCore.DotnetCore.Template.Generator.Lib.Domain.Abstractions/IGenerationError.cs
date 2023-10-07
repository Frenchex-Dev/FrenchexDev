#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface IGenerationError
{
    string Error    { get; }
    string Path     { get; }
    string FileName { get; }
}