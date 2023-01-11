﻿using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using System.Reflection;

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