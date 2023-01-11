﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.Text;
using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Microsoft.Extensions.Configuration;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Command;

public abstract class RootCommand : IRootCommand
{
    private readonly string _vagrantBinPath;
    protected IFilesystem Filesystem;
    protected IProcessBuilder ProcessBuilder;

    protected RootCommand(
        IProcessBuilder processBuilder,
        IFilesystem fileSystem,
        IConfiguration configuration
    )
    {
        ProcessBuilder = processBuilder;
        Filesystem = fileSystem;
        _vagrantBinPath = configuration["VAGRANT_BIN_PATH"] ?? "vagrant";
    }

    private string GetBinary()
    {
        return _vagrantBinPath;
    }

    protected ProcessExecutionResult BuildAndStartProcess(
        IRootCommandRequest request,
        IRootCommandResponseBuilder responseBuilder,
        string arguments
    )
    {
        var process = Build(new ProcessBuildingParameters(
            GetBinary(),
            arguments,
            request.Base.WorkingDirectory,
            request.Base.Timeout,
            false,
            true,
            true,
            true,
            true
        ));

        var processExecutionResult = process.Start();

        responseBuilder
            .SetProcess(process)
            .SetProcessExecutionResult(processExecutionResult)
            ;

        return processExecutionResult;
    }

    private IProcess Build(ProcessBuildingParameters buildParameters)
    {
        return ProcessBuilder.Build(buildParameters);
    }

    protected static string BuildRootPackerOptions(IBaseCommandRequest request)
    {
        return new StringBuilder()
                .ToString()
            ;
    }
}