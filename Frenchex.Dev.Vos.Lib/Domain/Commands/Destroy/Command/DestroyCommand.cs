using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Command;

public class DestroyCommand : RootCommand, IDestroyCommand
{
    private readonly IDestroyCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command.IDestroyCommand _vagrantDestroyCommand;

    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request.IDestroyCommandRequestBuilderFactory
        _vagrantDestroyCommandRequestBuilderFactory;

    public DestroyCommand(
        IDestroyCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter nameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command.IDestroyCommand destroyCommand,
        Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request.IDestroyCommandRequestBuilderFactory
            destroyCommandRequestBuilderFactory
    ) : base(configurationLoadAction, nameConverter)
    {
        _responseBuilderFactory = responseBuilderFactory;
        _vagrantDestroyCommand = destroyCommand;
        _vagrantDestroyCommandRequestBuilderFactory = destroyCommandRequestBuilderFactory;
    }

    public async Task<IDestroyCommandResponse> ExecuteAsync(IDestroyCommandRequest request)
    {
        var process = _vagrantDestroyCommand.StartProcess(_vagrantDestroyCommandRequestBuilderFactory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(request.Base.WorkingDirectory)
            .UsingTimeout(request.DestroyTimeout)
            .Parent<Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request.IDestroyCommandRequestBuilder>()
            .UsingName(
                !string.IsNullOrEmpty(request.Name)
                    ? MapNamesToVagrantNames(
                        new[] {request.Name},
                        request.Base.WorkingDirectory,
                        await ConfigurationLoad(request.Base.WorkingDirectory)
                    )[0]
                    : ""
            )
            .WithForce(true)
            .Build()
        );

        if (null == process.ProcessExecutionResult.WaitForCompleteExit)
            throw new InvalidOperationException("waitforcompleteexit is null");

        await process.ProcessExecutionResult.WaitForCompleteExit;

        var responseBuilder = _responseBuilderFactory.Build();

        return responseBuilder.Build();
    }
}