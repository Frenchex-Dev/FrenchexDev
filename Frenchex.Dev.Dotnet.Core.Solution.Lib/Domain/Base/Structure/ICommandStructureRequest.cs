#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Domain.Base.Structure;

public interface ICommandStructureRequest
{
    public DirectoryStructureGenerator DirectoryStructureGenerator { get; init; }
    public FilesGenerator FilesGenerator { get; init; }
}