using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Command;

public class UpCommand : RootCommand, IUpCommand
{
    private readonly IUpCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Domain.Commands.Up.IUpCommand _vagrantUpCommand;

    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Up.Request.IUpCommandRequestBuilderFactory
        _vagrantUpCommandRequestBuilderFactory;

    public UpCommand(
        IUpCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter vexNameToVagrantNameConverter,
        Vagrant.Lib.Domain.Commands.Up.IUpCommand vagrantUpCommand,
        Vagrant.Lib.Abstractions.Domain.Commands.Up.Request.IUpCommandRequestBuilderFactory
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
            .UsingWorkingDirectory(request.Base.WorkingDirectory)
            .UsingTimeout(request.Base.Timeout)
            .Parent<Vagrant.Lib.Abstractions.Domain.Commands.Up.Request.IUpCommandRequestBuilder>()
            .UsingNamesOrIds(
                MapNamesToVagrantNames(
                    request.Names,
                    request.Base.WorkingDirectory,
                    await ConfigurationLoad(request.Base.WorkingDirectory)
                )
            )
            .Build();

        var vagrantUpProcess = _vagrantUpCommand.StartProcess(libRequest);

        return _responseBuilderFactory.Factory()
            .WithUpResponse(vagrantUpProcess)
            .Build();
    }
}