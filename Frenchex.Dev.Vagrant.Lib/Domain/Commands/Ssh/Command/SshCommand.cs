using System.Text;
using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Command;

public class SshCommand : RootCommand, ISshCommand
{
    private readonly ISshCommandResponseBuilderFactory _responseBuilderFactory;

    public SshCommand(
        IProcessBuilder processExecutor,
        IFilesystem fileSystem,
        ISshCommandResponseBuilderFactory responseBuilderFactory,
        IConfiguration configuration
    ) : base(processExecutor, fileSystem, configuration)
    {
        _responseBuilderFactory = responseBuilderFactory;
    }

    public ISshCommandResponse StartProcess(ISshCommandRequest request)
    {
        var responseBuilder = _responseBuilderFactory.Build();

        BuildAndStartProcess(
            request,
            responseBuilder,
            BuildArguments(request)
        );

        return responseBuilder.Build();
    }

    public string GetCliCommandName()
    {
        return "ssh";
    }

    public string BuildArguments(ISshCommandRequest request)
    {
        return GetCliCommandName() + " " + BuildVagrantOptions(request) + " " + BuildVagrantArguments(request);
    }

    private static string BuildVagrantOptions(ISshCommandRequest request)
    {
        return new StringBuilder()
                .Append(!string.IsNullOrEmpty(request.Command) ? $" --command \"{request.Command}\"" : "")
                .Append(request.Plain ? " --plain" : "")
                .Append(BuildRootVagrantOptions(request.Base))
                .ToString()
            ;
    }

    private static string BuildVagrantArguments(ISshCommandRequest request)
    {
        return request.NameOrId;
    }
}