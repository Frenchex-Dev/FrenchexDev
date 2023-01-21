#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Options;

public interface IWorkingDirectoryOptionBuilder
{
    Option<string> Build();
}

public class WorkingDirectoryOptionBuilder : IWorkingDirectoryOptionBuilder
{
    public Option<string> Build()
    {
        return new Option<string>(
            new[] { "--working-directory", "-w" },
            Directory.GetCurrentDirectory,
            "Working Directory"
        );
    }
}