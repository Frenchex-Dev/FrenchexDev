#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;
using IUpCommandRequest = Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request.IUpCommandRequest;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Command;

public class UpCommand : RootCommand, IUpCommand
{
    private readonly IUpCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Up.Command.IUpCommand _vagrantUpCommand;

    private readonly IUpCommandRequestBuilderFactory
        _vagrantUpCommandRequestBuilderFactory;

    public UpCommand(
        IUpCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVosNameToVagrantNameConverter vosNameToVagrantNameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Up.Command.IUpCommand vagrantUpCommand,
        IUpCommandRequestBuilderFactory
            vagrantUpCommandRequestBuilderFactory
    ) : base(configurationLoadAction, vosNameToVagrantNameConverter)
    {
        _responseBuilderFactory = responseBuilderFactory;
        _vagrantUpCommand = vagrantUpCommand;
        _vagrantUpCommandRequestBuilderFactory = vagrantUpCommandRequestBuilderFactory;
    }

    public async Task<IUpCommandResponse> ExecuteAsync(IUpCommandRequest request)
    {
        var libRequest = _vagrantUpCommandRequestBuilderFactory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(request.BaseCommand.WorkingDirectory)
            .UsingTimeout(request.BaseCommand.Timeout)
            .Parent<IUpCommandRequestBuilder>()
            .UsingNamesOrIds(
                MapNamesToVagrantNames(
                    request.Names,
                    request.BaseCommand.WorkingDirectory,
                    await ConfigurationLoad(request.BaseCommand.WorkingDirectory)
                )
            )
            .Build();

        var vagrantUpProcess = _vagrantUpCommand.StartProcess(libRequest);

        return _responseBuilderFactory.Factory()
            .WithUpResponse(vagrantUpProcess)
            .Build();
    }
}