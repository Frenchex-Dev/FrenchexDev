﻿using System.Text;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Infrastructure;

public class GeneratedCodeWriter(
    IFileWriter fileWriter
) : IGeneratedCodeWriter
{
    public async Task WriteAsync(
        IList<IGeneratedFile> files
      , CancellationToken     cancellationToken = default
    )
    {
        await CreateDirectories(files);
        await Parallel.ForEachAsync(files.AsEnumerable(), new ParallelOptions
                                                          {
                                                              CancellationToken      = cancellationToken
                                                            , MaxDegreeOfParallelism = 500
                                                            , TaskScheduler          = TaskScheduler.Current
                                                          }, async (
                                                                 x
                                                               , ct
                                                             ) =>
                                                             {
                                                                 await fileWriter.WriteAllTextAsync(x.Path, x.Content
                                                                                                  , Encoding.Unicode
                                                                                                  , ct);
                                                             });
    }

    private Task CreateDirectories(
        IList<IGeneratedFile> files
    )
    {
        var directories = new Dictionary<string, DirectoryInfo>();
        files.ToList()
             .ForEach(file =>
                      {
                          var dirInfo = new FileInfo(file.Path);

                          if (dirInfo.Directory == null) throw new DirectoryNotFoundException(dirInfo.FullName);

                          directories.TryAdd(dirInfo.Directory.FullName, dirInfo.Directory);
                      });

        directories.Values.ToList()
                   .ForEach(file => { file.Create(); });

        return Task.CompletedTask;
    }
}