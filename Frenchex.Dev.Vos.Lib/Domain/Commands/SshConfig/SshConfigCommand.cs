using Frenchex.Dev.Vos.Lib.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig;

public class SshConfigCommand : RootCommand, ISshConfigCommand
{
    private readonly ISshConfigCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command.ISshConfigCommand _vagrantSshConfigCommand;

    private readonly Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request.ISshConfigCommandRequestBuilderFactory
        _vagrantSshConfigCommandRequestBuilderFactory;

    public SshConfigCommand(
        ISshConfigCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter nameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command.ISshConfigCommand vagrantSshConfigCommand,
        Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request.ISshConfigCommandRequestBuilderFactory
            vagrantSshConfigCommandRequestBuilder
    ) : base(configurationLoadAction, nameConverter)
    {
        _responseBuilderFactory = responseBuilderFactory;
        _vagrantSshConfigCommand = vagrantSshConfigCommand;
        _vagrantSshConfigCommandRequestBuilderFactory = vagrantSshConfigCommandRequestBuilder;
    }

    public async Task<ISshConfigCommandResponse> Execute(ISshConfigCommandRequest request)
    {
        var process = _vagrantSshConfigCommand.StartProcess(_vagrantSshConfigCommandRequestBuilderFactory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(request.Base.WorkingDirectory)
            .UsingTimeoutMiliseconds(request.Base.TimeoutInMiliSeconds)
            .Parent<Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request.ISshConfigCommandRequestBuilder>()
            .UsingName(
                MapNamesToVagrantNames(
                    request.NamesOrIds,
                    request.Base.WorkingDirectory,
                    await ConfigurationLoad(request.Base.WorkingDirectory)
                )[0]
            )
            .Build()
        );

        if (null == process.ProcessExecutionResult.WaitForCompleteExit)
            throw new InvalidOperationException("wait for complete exit is null");

        await process.ProcessExecutionResult.WaitForCompleteExit;

        var responseBuilder = _responseBuilderFactory.Build();

        return responseBuilder.Build();
    }
}