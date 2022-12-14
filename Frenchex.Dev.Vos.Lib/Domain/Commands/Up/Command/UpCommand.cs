using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;
using IUpCommandRequest = Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request.IUpCommandRequest;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Command;

public class UpCommand : RootCommand, IUpCommand
{
    private readonly IUpCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Domain.Commands.Up.IUpCommand _vagrantUpCommand;

    private readonly IUpCommandRequestBuilderFactory
        _vagrantUpCommandRequestBuilderFactory;

    public UpCommand(
        IUpCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter vexNameToVagrantNameConverter,
        Vagrant.Lib.Domain.Commands.Up.IUpCommand vagrantUpCommand,
        IUpCommandRequestBuilderFactory
            vagrantUpCommandRequestBuilderFactory
    ) : base(configurationLoadAction, vexNameToVagrantNameConverter)
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