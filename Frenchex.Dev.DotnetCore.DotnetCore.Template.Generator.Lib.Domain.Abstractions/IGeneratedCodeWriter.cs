#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface IGeneratedCodeWriter
{
    Task WriteAsync(
        IList<IGeneratedFile> files
      , CancellationToken     cancellationToken = default
    );
}