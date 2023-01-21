#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public class CommandStructureBuilder
{
    private DirectoryStructureGenerator? _directoryStructureGenerator;
    private FilesGenerator? _filesGenerator;

    public CommandStructureRequest Build()
    {
        return new CommandStructureRequest(
            _directoryStructureGenerator ?? throw new ArgumentNullException(nameof(_directoryStructureGenerator)),
            _filesGenerator ?? throw new ArgumentNullException(nameof(_filesGenerator))
        );
    }

    public CommandStructureBuilder WithDirectoryStructureGenerator(
        DirectoryStructureGenerator directoryStructureGenerator)
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