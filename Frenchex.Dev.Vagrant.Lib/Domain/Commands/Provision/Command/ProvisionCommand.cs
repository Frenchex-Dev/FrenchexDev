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
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Command;
using Microsoft.Extensions.Configuration;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Command;

public class ProvisionCommand : RootCommand, IProvisionCommand
{
    private readonly IProvisionCommandResponseBuilderFactory _provisionCommandResponseBuilderFactory;

    public ProvisionCommand(
        IProcessBuilder processBuilder,
        IFilesystem fileSystem,
        IConfiguration configuration,
        IProvisionCommandResponseBuilderFactory provisionCommandResponseBuilderFactory
    ) : base(processBuilder, fileSystem, configuration)
    {
        _provisionCommandResponseBuilderFactory = provisionCommandResponseBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "provision";
    }

    public IProvisionCommandResponse StartProcess(IProvisionCommandRequest request)
    {
        var responseBuilder = _provisionCommandResponseBuilderFactory.Build();

        BuildAndStartProcess(
            request,
            responseBuilder,
            BuildArguments(request)
        );

        return responseBuilder.Build();
    }

    private string BuildArguments(IProvisionCommandRequest request)
    {
        return GetCliCommandName() + " " + BuildVagrantArguments(request) + BuildVagrantOptions(request);
    }


    private static string BuildVagrantOptions(IProvisionCommandRequest request)
    {
        if (null == request.Base) throw new InvalidOperationException("request.Base is null");

        var sb = new StringBuilder();

        if (!string.IsNullOrEmpty(request.VmName)) sb.Append(request.VmName);

        if (request.ProvisionWith != null && request.ProvisionWith.Any())
            foreach (var provisionWith in request.ProvisionWith)
                sb.Append("--provision-with " + provisionWith);

        return sb
                .Append(BuildRootVagrantOptions(request.Base))
                .ToString()
            ;
    }

    private static string BuildVagrantArguments(IProvisionCommandRequest request)
    {
        return string.Empty;
    }

    protected static string BuildArguments(string command, IProvisionCommandRequest request)
    {
        return
            $"{command} " +
            $"{BuildVagrantOptions(request)} " +
            $"{BuildVagrantArguments(request)}"
            ;
    }
}