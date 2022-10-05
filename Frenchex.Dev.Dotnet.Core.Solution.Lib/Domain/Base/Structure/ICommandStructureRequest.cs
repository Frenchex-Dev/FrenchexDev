namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public interface ICommandStructureRequest
{
    public DirectoryStructureGenerator DirectoryStructureGenerator { get; init; }
    public FilesGenerator FilesGenerator { get; init; }
}