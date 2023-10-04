#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

public class FileWriter : IFileWriter
{
    public async Task WriteAllTextAsync(
        string            path
      , string            content
      , Encoding          encoding
      , CancellationToken cancellationToken = default
    )
    {
        await File.WriteAllTextAsync(path, content, encoding, cancellationToken);
    }
}
