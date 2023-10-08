#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Licensing

// Licensing please read LICENSE.md

#endregion


#region Usings

using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain;

public interface IGeneratedCodeWriter
{
    Task WriteAsync(
        IList<IGeneratedFile> files
      , CancellationToken     cancellationToken = default
    );
}
