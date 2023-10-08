#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text;
using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain;
using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Infrastructure;

/// <summary>
/// </summary>
/// <param name="fileWriter"></param>
public class GeneratedCodeWriter(
    IFileWriter                 fileWriter
  , IGeneratedCodeWriterOptions options
) : IGeneratedCodeWriter
{
    /// <summary>
    /// </summary>
    /// <param name="files"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task WriteAsync(
        IList<IGeneratedFile> files
      , CancellationToken     cancellationToken = default
    )
    {
        await CreateDirectories(files);
        await Parallel.ForEachAsync(
                                    files.AsEnumerable()
                                  , new ParallelOptions
                                    {
                                        CancellationToken      = cancellationToken
                                      , MaxDegreeOfParallelism = options.WriteFilesMaxConcurrency
                                      , TaskScheduler          = TaskScheduler.Current
                                    }
                                  , async (
                                        x
                                      , ct
                                    ) =>
                                    {
                                        await fileWriter.WriteAllTextAsync(x.Path, x.Content, Encoding.UTF8, ct);
                                    });
    }

    private static Task CreateDirectories(
        IList<IGeneratedFile> files
    )
    {
        var directories = new Dictionary<string, DirectoryInfo>();

        files
            .ToList()
            .ForEach(
                     file =>
                     {
                         var dirInfo = new FileInfo(file.Path);
                         if (dirInfo.Directory == null) return;
                         directories.TryAdd(dirInfo.Directory.FullName, dirInfo.Directory);
                     });

        directories
            .Values
            .ToList()
            .ForEach(directory => { directory.Create(); });

        return Task.CompletedTask;
    }
}
