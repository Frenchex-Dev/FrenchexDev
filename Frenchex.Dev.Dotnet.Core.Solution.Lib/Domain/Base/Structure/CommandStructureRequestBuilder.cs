namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class CommandStructureBuilder
{
    private DirectoryStructureGenerator _directoryStructureGenerator;
    private FilesGenerator _filesGenerator;

    public CommandStructureRequest Build()
    {
        return new CommandStructureRequest(
            _directoryStructureGenerator,
            _filesGenerator
        );
    }
    public CommandStructureBuilder WithDirectoryStructureGenerator(DirectoryStructureGenerator directoryStructureGenerator)
    {
        _directoryStructureGenerator = directoryStructureGenerator;
        return this;
    }

    public CommandStructureBuilder WithFilesGenerator(FilesGenerator filesGenerator)
    {
        _filesGenerator = filesGenerator;
        return this;
    }
}