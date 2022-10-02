using System.Text;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Command;

public class SshCommand : RootCommand, ISshCommand
{
    private readonly ISshCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command.ISshCommand _vagrantSshCommand;

    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request.ISshCommandRequestBuilderFactory
        _vagrantSshCommandRequestBuilderFactory;

    public SshCommand(
        ISshCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVexNameToVagrantNameConverter nameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command.ISshCommand vagrantSshCommand,
        Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request.ISshCommandRequestBuilderFactory
            sshCommandRequestBuilderFactory
    ) : base(configurationLoadAction, nameConverter)
    {
        _responseBuilderFactory = responseBuilderFactory;
        _vagrantSshCommand = vagrantSshCommand;
        _vagrantSshCommandRequestBuilderFactory = sshCommandRequestBuilderFactory;
    }

    public async Task<ISshCommandResponse> ExecuteAsync(ISshCommandRequest request)
    {
        foreach (var command in request.Commands)
        {
            var vagrantMachines = MapNamesToVagrantNames(
                request.NamesOrIds,
                request.Base.WorkingDirectory,
                await ConfigurationLoad(request.Base.WorkingDirectory)
            );

            foreach (var vagrantMachine in vagrantMachines)
            {
                var response = _vagrantSshCommand.StartProcess(_vagrantSshCommandRequestBuilderFactory.Factory()
                    .BaseBuilder
                    .UsingTimeout(request.Base.Timeout)
                    .UsingWorkingDirectory(request.Base.WorkingDirectory)
                    .Parent<Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request.ISshCommandRequestBuilder>()
                    .UsingCommand(command)
                    .UsingNameOrId(vagrantMachine)
                    .Build()
                );

                if (null == response.ProcessExecutionResult.WaitForCompleteExit)
                    throw new InvalidOperationException("wait for complete exit is null");

                await response.ProcessExecutionResult.WaitForCompleteExit;

                var output =
                    Encoding.UTF8.GetString(response.ProcessExecutionResult.OutputStream?.ToArray() ??
                                            Array.Empty<byte>());
            }
        }

        var responseBuilder = _responseBuilderFactory.Build();

        return responseBuilder.Build();
    }
}