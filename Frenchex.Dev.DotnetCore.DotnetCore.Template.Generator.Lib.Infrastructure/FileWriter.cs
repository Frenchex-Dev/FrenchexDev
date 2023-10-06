#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure
{
    /// <summary>
    /// </summary>
    public class FileWriter : IFileWriter
    {
        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
}
