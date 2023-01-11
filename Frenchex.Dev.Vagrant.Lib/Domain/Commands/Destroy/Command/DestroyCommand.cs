#region Licensing

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
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

#endregion

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

    private string BuildArguments(IDestroyCommandRequest request)
    {
        return GetCliCommandName() + " " + BuildVagrantOptions(request) + " " + BuildVagrantArguments(request);
    }

    private static string BuildVagrantOptions(IDestroyCommandRequest request)
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

    private static string BuildVagrantArguments(IDestroyCommandRequest request)
    {
        return request.NameOrId;
    }
}