#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Command;

public class StatusCommand : RootCommand, IStatusCommand
{
    private readonly IStatusCommandResponseBuilderFactory _responseBuilderFactory;

    public StatusCommand(
        IProcessBuilder processExecutor,
        IFilesystem fileSystem,
        IStatusCommandResponseBuilderFactory responseBuilderFactory,
        IConfiguration configuration
    ) : base(processExecutor, fileSystem, configuration)
    {
        _responseBuilderFactory = responseBuilderFactory;
    }

    public IStatusCommandResponse StartProcess(IStatusCommandRequest request)
    {
        var responseBuilder = _responseBuilderFactory.Build();

        var processExecution = BuildAndStartProcess(
            request,
            responseBuilder,
            BuildArguments(request)
        );

        if (null == processExecution) throw new InvalidDataException("ProcessExecution");

        if (null == processExecution.WaitForCompleteExit) throw new InvalidDataException("WaitForCompleteExit");

        if (null == processExecution.OutputStream) throw new InvalidDataException("OutputStream");

        return responseBuilder
            .Build();
    }

    public string GetCliCommandName()
    {
        return "status";
    }

    private string BuildArguments(IStatusCommandRequest request)
    {
        return $"{GetCliCommandName()} {string.Join(" ", request.NamesOrIds)}";
    }
}