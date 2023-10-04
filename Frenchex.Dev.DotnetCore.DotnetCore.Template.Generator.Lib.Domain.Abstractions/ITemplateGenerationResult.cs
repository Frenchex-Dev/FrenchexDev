#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface ITemplateGenerationResult
{
    IList<IGeneratedFile>   Generation { get; }
    IList<IGenerationError> Errors     { get; }
}
