#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Command.Generator;

public class CommandGeneratorCommand
{
    private readonly IFilesystem _filesystem;

    public CommandGeneratorCommand(
        IFilesystem filesystem
    )
    {
        _filesystem = filesystem;
    }

    public async Task ExecuteAsync(CommandGeneratorRequest commandGeneratorRequest)
    {
        await CreateDirectoryIfDoesNotExists(commandGeneratorRequest.BasePath);
        // await GenerateDirectoryStructure(commandGeneratorRequest.BasePath);
    }

    private Task CreateDirectoryIfDoesNotExists(string basePath)
    {
        if (_filesystem.DirectoryExists(basePath)) _filesystem.DirectoryDelete(basePath, true);

        return Task.CompletedTask;
    }
}