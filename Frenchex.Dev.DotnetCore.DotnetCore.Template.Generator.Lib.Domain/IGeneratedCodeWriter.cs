using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface IGeneratedCodeWriter
{
    Task WriteAsync(
        IList<IGeneratedFile> files
      , CancellationToken     cancellationToken = default
    );
}
