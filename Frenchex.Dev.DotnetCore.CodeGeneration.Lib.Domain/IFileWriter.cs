#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text;

#endregion

namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain;

public interface IFileWriter
{
    Task WriteAllTextAsync(
        string            path
      , string            content
      , Encoding          encoding
      , CancellationToken cancellationToken = default
    );
}
