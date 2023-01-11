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
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Command;

public class HaltCommand : RootCommand, IHaltCommand
{
    private readonly IHaltCommandResponseBuilderFactory _responseBuilderFactory;

    public HaltCommand(
        IProcessBuilder processBuilder,
        IFilesystem fileSystem,
        IHaltCommandResponseBuilderFactory responseBuilderFactory,
        IConfiguration configuration
    ) : base(processBuilder, fileSystem, configuration)
    {
        _responseBuilderFactory = responseBuilderFactory;
    }

    public IHaltCommandResponse StartProcess(IHaltCommandRequest request)
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
        return "halt";
    }

    public string BuildArguments(IHaltCommandRequest request)
    {
        return GetCliCommandName() + " " + BuildVagrantOptions(request) + " " + BuildVagrantArguments(request);
    }

    protected static string BuildVagrantOptions(IHaltCommandRequest request)
    {
        if (null == request.Base) throw new InvalidOperationException("request.Base is null");

        return new StringBuilder()
                .Append(request.Force ? " --force" : "")
                .Append(BuildRootVagrantOptions(request.Base))
                .ToString()
            ;
    }

    protected static string BuildVagrantArguments(IHaltCommandRequest request)
    {
        return request.NamesOrIds is { Length: > 0 } ? string.Join(" ", request.NamesOrIds) : "";
    }
}