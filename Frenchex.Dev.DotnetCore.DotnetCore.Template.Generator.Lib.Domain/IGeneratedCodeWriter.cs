#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface IGeneratedCodeWriter
{
    Task WriteAsync(
        IList<IGeneratedFile> files
      , CancellationToken     cancellationToken = default
    );
}
