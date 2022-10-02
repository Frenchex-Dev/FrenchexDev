using System.Text;
using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Command;

public class DestroyCommand : RootCommand, IDestroyCommand
{
    private readonly IDestroyCommandResponseBuilderFactory _responseBuilderFactory;

    public DestroyCommand(
        IProcessBuilder processExecutor,
        IFilesystem fileSystem,
        IDestroyCommandResponseBuilderFactory responseBuilderFactory,
        IConfiguration configuration
    ) : base(processExecutor, fileSystem, configuration)
    {
        _responseBuilderFactory = responseBuilderFactory;
    }

    public IDestroyCommandResponse StartProcess(IDestroyCommandRequest request)
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
        return "destroy";
    }

    public string BuildArguments(IDestroyCommandRequest request)
    {
        return GetCliCommandName() + " " + BuildVagrantOptions(request) + " " + BuildVagrantArguments(request);
    }

    protected static string BuildVagrantOptions(IDestroyCommandRequest request)
    {
        if (null == request.Base) throw new InvalidOperationException("request.base is null");

        return new StringBuilder()
                .Append(request.Force ? " --force" : "")
                .Append(request.Parallel ? " --parallel" : "")
                .Append(request.Graceful ? " --graceful" : "")
                .Append(BuildRootVagrantOptions(request.Base))
                .ToString()
            ;
    }

    protected static string BuildVagrantArguments(IDestroyCommandRequest request)
    {
        return request.NameOrId;
    }
}