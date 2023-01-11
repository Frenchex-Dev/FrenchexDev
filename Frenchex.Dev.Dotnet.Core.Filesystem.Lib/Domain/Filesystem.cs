#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;

public class Filesystem : IFilesystem
{
    #region Directory

    public void DirectoryDelete(string contextWorkingDirectory, bool recursive)
    {
        Directory.Delete(contextWorkingDirectory, recursive);
    }

    public bool TryDirectoryDelete(string contextWorkingDirectory, bool recursive)
    {
        try
        {
            Directory.Delete(contextWorkingDirectory, recursive);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public DirectoryInfo DirectoryCreate(string? path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(nameof(path));

        return Directory.CreateDirectory(path);
    }

    public void DirectoryCopy(string source, string target)
    {
        if (!Directory.Exists(target))
            Directory.CreateDirectory(target);

        var files = Directory.GetFiles(source);
        foreach (var file in files)
        {
            var name = Path.GetFileName(file);
            var dest = Path.Combine(target, name);
            File.Copy(file, dest);
        }

        var folders = Directory.GetDirectories(source);
        foreach (var folder in folders)
        {
            var name = Path.GetFileName(folder);
            var dest = Path.Combine(target, name);
            DirectoryCopy(folder, dest);
        }
    }

    public bool DirectoryExists(string? path)
    {
        return Directory.Exists(path);
    }

    #endregion

    #region File

    public void FileCopy(string v1, string v2)
    {
        File.Copy(v1, v2);
    }

    public void FileDelete(string filepath)
    {
        File.Delete(filepath);
    }

    public async Task FileWriteAllTextAsync(string path, string content)
    {
        await File.WriteAllTextAsync(path, content);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public async Task<string> FileReadAllText(string path)
    {
        return await File.ReadAllTextAsync(path);
    }

    #endregion File
}