using System.Text;
using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Response;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;
using Microsoft.Extensions.Configuration;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Command;

public abstract class RootCommand : IRootCommand
{
    private readonly string _vagrantBinPath;
    private IFilesystem _filesystem;
    private readonly IProcessBuilder _processBuilder;

    protected RootCommand(
        IProcessBuilder processBuilder,
        IFilesystem fileSystem,
        IConfiguration configuration
    )
    {
        _processBuilder = processBuilder;
        _filesystem = fileSystem;
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
        return _processBuilder.Build(buildParameters);
    }

    protected static string BuildRootPackerOptions(IBaseCommandRequest request)
    {
        return new StringBuilder()
                .ToString()
            ;
    }
}