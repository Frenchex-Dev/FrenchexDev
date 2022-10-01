using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Command;

public class BuildCommand : RootCommand, IBuildCommand
{
    private readonly IBuildCommandResponseBuilderFactory _buildCommandResponseBuilderFactory;

    public BuildCommand(
        IProcessBuilder processBuilder,
        IFilesystem fileSystem,
        IConfiguration configuration,
        IBuildCommandResponseBuilderFactory buildCommandResponseBuilderFactory
    ) : base(
        processBuilder,
        fileSystem,
        configuration)
    {
        _buildCommandResponseBuilderFactory = buildCommandResponseBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "build";
    }

    public IBuildCommandResponse StartProcess(IBuildCommandRequest request)
    {
        var responseBuilder = _buildCommandResponseBuilderFactory.Factory();

        return responseBuilder.Build();
    }
}