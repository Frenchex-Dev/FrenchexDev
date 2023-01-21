#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;

public interface IFilesystem
{
    #region Directory

    DirectoryInfo DirectoryCreate(string path);
    bool DirectoryExists(string path);
    void DirectoryCopy(string source, string target);
    void DirectoryDelete(string contextWorkingDirectory, bool recursive);
    bool TryDirectoryDelete(string contextWorkingDirectory, bool recursive);

    #endregion

    #region File

    void FileCopy(string sourceFile, string destinationFile);
    void FileDelete(string filepath);
    Task FileWriteAllTextAsync(string path, string content);
    bool FileExists(string path);
    Task<string> FileReadAllText(string path);

    #endregion
}