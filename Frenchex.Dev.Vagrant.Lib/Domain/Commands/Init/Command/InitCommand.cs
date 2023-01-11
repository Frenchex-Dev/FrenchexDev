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
using Frenchex.Dev.Dotnet.Core.Process.Lib.Domain.ProcessBuilder;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Command;

public class InitCommand : RootCommand, IInitCommand
{
    private readonly IInitCommandResponseBuilderFactory _responseBuilderFactory;

    public InitCommand(
        IProcessBuilder processExecutor,
        IFilesystem fileSystem,
        IInitCommandResponseBuilderFactory responseBuilderFactory,
        IConfiguration configuration
    ) : base(processExecutor, fileSystem, configuration)
    {
        _responseBuilderFactory = responseBuilderFactory;
    }

    public IInitCommandResponse StartProcess(IInitCommandRequest request)
    {
        var responseBuilder = _responseBuilderFactory.Build();

        if (!Filesystem.DirectoryExists(request.Base.WorkingDirectory!))
            Filesystem.DirectoryCreate(request.Base.WorkingDirectory!);

        BuildAndStartProcess(
            request,
            responseBuilder,
            BuildArguments(request)
        );

        return responseBuilder.Build();
    }

    public string GetCliCommandName()
    {
        return "init";
    }

    public string BuildArguments(IInitCommandRequest request)
    {
        return GetCliCommandName() + " " + BuildVagrantArguments(request) + BuildVagrantOptions(request);
    }

    protected static string BuildVagrantOptions(IInitCommandRequest request)
    {
        if (null == request.Base) throw new InvalidOperationException("request.Base is null");

        return new StringBuilder()
                .Append(!string.IsNullOrEmpty(request.BoxVersion) ? $" --box-version {request.BoxVersion}" : "")
                .Append(request.Force.HasValue ? " --force" : "")
                .Append(request.Minimal.HasValue ? " --minimal" : "")
                .Append(!string.IsNullOrEmpty(request.OutputToFile) ? $" --output {request.OutputToFile}" : "")
                .Append(!string.IsNullOrEmpty(request.TemplateFile) ? $" --template {request.TemplateFile}" : "")
                .Append(BuildRootVagrantOptions(request.Base))
                .ToString()
            ;
    }

    protected static string BuildVagrantArguments(IInitCommandRequest request)
    {
        if (null == request || null == request.BoxName)
            throw new InvalidOperationException("request or boxname is null");

        return request.BoxName;
    }

    protected static string BuildArguments(string command, IInitCommandRequest request)
    {
        return
            $"{command} " +
            $"{BuildVagrantOptions(request)} " +
            $"{BuildVagrantArguments(request)}"
            ;
    }
}