using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Command;

public class HaltCommand : RootCommand, IHaltCommand
{
    private readonly IHaltCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command.IHaltCommand _vagrantHaltCommand;

    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request.IHaltCommandRequestBuilderFactory
        _vagrantHaltCommandRequestBuilderFactory;

    public HaltCommand(
        IHaltCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter vexNameToVagrantNameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command.IHaltCommand vagrantHaltCommand,
        Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request.IHaltCommandRequestBuilderFactory
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
            .UsingWorkingDirectory(request.Base.WorkingDirectory)
            .UsingTimeout(request.Base.Timeout)
            .Parent<Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request.IHaltCommandRequestBuilder>()
            .UsingNamesOrIds(
                MapNamesToVagrantNames(
                    request.Names,
                    request.Base.WorkingDirectory,
                    await ConfigurationLoad(request.Base.WorkingDirectory)
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