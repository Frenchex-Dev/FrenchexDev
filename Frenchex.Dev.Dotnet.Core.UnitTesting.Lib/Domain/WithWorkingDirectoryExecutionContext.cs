#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;

public abstract class WithWorkingDirectoryExecutionContext
{
    public string? WorkingDirectory { get; set; }

    public static string CreateTemporaryDirectory()
    {
        return Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
    }
}