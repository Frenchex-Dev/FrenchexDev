#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.Reflection;
using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Resources;

public interface IScriptsResource
{
    void Copy(string? destination);
}

public class ScriptsResource : IScriptsResource
{
    private readonly IFilesystem _fileSystem;
    private readonly string _scriptsSourcePath;

    public ScriptsResource(IFilesystem fileSystem)
    {
        var assembly = Assembly.GetAssembly(typeof(VagrantfileResource));
        if (null == assembly) throw new InvalidOperationException("assembly is null");

        _fileSystem = fileSystem;
        _scriptsSourcePath = Path.Join(
            Path.GetDirectoryName(assembly.Location),
            "Resources",
            "Scripts"
        );
    }

    public void Copy(string? destination)
    {
        _fileSystem.DirectoryCopy(_scriptsSourcePath, Path.Join(destination, "Scripts"));
    }
}