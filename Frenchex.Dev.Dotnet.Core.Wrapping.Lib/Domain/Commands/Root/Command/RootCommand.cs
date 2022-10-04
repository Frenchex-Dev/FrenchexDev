using System.Text;
using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.Process;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Command;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Response;
using Microsoft.Extensions.Configuration;

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root.Command;

public abstract class RootCommand : IRootCommand
{
    private readonly string _vagrantBinPath;
    private IFilesystem _filesystem;
    private readonly IProcessBuilder ProcessBuilder;

    protected RootCommand(
        IProcessBuilder processBuilder,
        IFilesystem fileSystem,
        IConfiguration configuration
    )
    {
        ProcessBuilder = processBuilder;
        _filesystem = fileSystem;
        _vagrantBinPath = configuration["VAGRANT_BIN_PATH"] ?? "vagrant";
    }

    private string GetBinary()
    {
        return _vagrantBinPath;
    }

    protected ProcessExecutionResult BuildAndStartProcess<T>(
        IRootCommandRequest<T> request,
        IRootCommandResponseBuilder responseBuilder,
        string arguments
    ) where T : IBaseCommandRequest
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

    protected static string BuildRootVagrantOptions(IBaseCommandRequest request)
    {
        return new StringBuilder()
                .ToString()
            ;
    }
}