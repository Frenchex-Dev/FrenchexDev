using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;
using IHaltCommandRequest = Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request.IHaltCommandRequest;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Command;

public class HaltCommand : RootCommand, IHaltCommand
{
    private readonly IHaltCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command.IHaltCommand _vagrantHaltCommand;

    private readonly IHaltCommandRequestBuilderFactory
        _vagrantHaltCommandRequestBuilderFactory;

    public HaltCommand(
        IHaltCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter vexNameToVagrantNameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command.IHaltCommand vagrantHaltCommand,
        IHaltCommandRequestBuilderFactory
            vagrantHaltCommandRequestBuilderFactory
    ) : base(configurationLoadAction, vexNameToVagrantNameConverter)
    {
        _responseBuilderFactory = responseBuilderFactory;
        _vagrantHaltCommand = vagrantHaltCommand;
        _vagrantHaltCommandRequestBuilderFactory = vagrantHaltCommandRequestBuilderFactory;
    }

    public async Task<IHaltCommandResponse> ExecuteAsync(IHaltCommandRequest request)
    {
        var libRequest = _vagrantHaltCommandRequestBuilderFactory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(request.BaseCommand.WorkingDirectory)
            .UsingTimeout(request.BaseCommand.Timeout)
            .Parent<IHaltCommandRequestBuilder>()
            .UsingNamesOrIds(
                MapNamesToVagrantNames(
                    request.Names,
                    request.BaseCommand.WorkingDirectory,
                    await ConfigurationLoad(request.BaseCommand.WorkingDirectory)
                )
            )
            .UsingHaltTimeout(request.HaltTimeout)
            .Build();

        var process = _vagrantHaltCommand.StartProcess(libRequest);

        return _responseBuilderFactory.Factory()
            .WithHaltResponse(process)
            .Build();
    }
}