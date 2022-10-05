namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class CommandStructureRequest : ICommandStructureRequest
{
    public CommandStructureRequest(
        DirectoryStructureGenerator directoryStructureGenerator,
        FilesGenerator filesGenerator
    )
    {
        DirectoryStructureGenerator = directoryStructureGenerator;
        FilesGenerator = filesGenerator;
    }

    public DirectoryStructureGenerator DirectoryStructureGenerator { get; init; }
    public FilesGenerator FilesGenerator { get; init; }
}