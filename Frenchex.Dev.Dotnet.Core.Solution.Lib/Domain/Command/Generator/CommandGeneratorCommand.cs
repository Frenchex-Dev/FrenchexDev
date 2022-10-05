using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

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

    private async Task CreateDirectoryIfDoesNotExists(string basePath)
    {
        if (_filesystem.DirectoryExists(basePath))
        {
            _filesystem.DirectoryDelete(basePath, true);
        }
    }
}