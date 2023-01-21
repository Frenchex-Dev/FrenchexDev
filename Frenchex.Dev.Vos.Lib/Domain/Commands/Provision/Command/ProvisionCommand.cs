#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Command;

public class ProvisionCommand : RootCommand, IProvisionCommand
{
    private readonly IProvisionCommandResponseBuilderFactory _provisionCommandResponseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command.IProvisionCommand _vagrantProvisionCommand;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request.IProvisionCommandRequestBuilderFactory
        _vagrantProvisionCommandRequestBuilderFactory;

    public ProvisionCommand(
        IConfigurationLoadAction configurationLoadAction,
        IVosNameToVagrantNameConverter vosNameToVagrantNameConverter,
        IProvisionCommandResponseBuilderFactory provisionCommandResponseBuilderFactory,
        Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command.IProvisionCommand provisionCommand,
        Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request.IProvisionCommandRequestBuilderFactory provisionCommandRequestBuilderFactory
    ) : base(configurationLoadAction, vosNameToVagrantNameConverter)
    {
        _provisionCommandResponseBuilderFactory = provisionCommandResponseBuilderFactory;
        _vagrantProvisionCommand = provisionCommand;
        _vagrantProvisionCommandRequestBuilderFactory = provisionCommandRequestBuilderFactory;
    }

    public async Task<IProvisionCommandResponse> ExecuteAsync(IProvisionCommandRequest request)
    {
        var libRequest = _vagrantProvisionCommandRequestBuilderFactory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(request.BaseCommand.WorkingDirectory)
            .UsingTimeout(request.BaseCommand.Timeout)
            .Parent<Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request.IProvisionCommandRequestBuilder>()
            .ProvisionVmName(
                MapNamesToVagrantNames(
                    request.Names,
                    request.BaseCommand.WorkingDirectory,
                    await ConfigurationLoad(request.BaseCommand.WorkingDirectory)
                ).First()
            )
            .ProvisionWith(request.ProvisionWith)
            .Build();

        var vagrantProvisionProcess = _vagrantProvisionCommand.StartProcess(libRequest);

        return _provisionCommandResponseBuilderFactory.Factory()
            .WithProvisionResponse(vagrantProvisionProcess)
            .Build();
    }
}