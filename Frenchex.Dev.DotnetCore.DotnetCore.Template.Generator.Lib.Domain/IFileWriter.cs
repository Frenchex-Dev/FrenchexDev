using System.Text;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface IFileWriter
{
    Task WriteAllTextAsync(
        string            path
      , string            content
      , Encoding          encoding
      , CancellationToken cancellationToken = default
    );
}
