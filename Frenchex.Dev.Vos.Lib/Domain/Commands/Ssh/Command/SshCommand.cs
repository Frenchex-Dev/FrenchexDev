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
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Load;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Command;
using ISshCommandRequest = Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request.ISshCommandRequest;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Command;

public class SshCommand : RootCommand, ISshCommand
{
    private readonly ISshCommandResponseBuilderFactory _responseBuilderFactory;
    private readonly Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command.ISshCommand _vagrantSshCommand;

    private readonly ISshCommandRequestBuilderFactory
        _vagrantSshCommandRequestBuilderFactory;

    public SshCommand(
        ISshCommandResponseBuilderFactory responseBuilderFactory,
        IConfigurationLoadAction configurationLoadAction,
        IVosNameToVagrantNameConverter nameConverter,
        Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command.ISshCommand vagrantSshCommand,
        ISshCommandRequestBuilderFactory
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
                request.BaseCommand.WorkingDirectory,
                await ConfigurationLoad(request.BaseCommand.WorkingDirectory)
            );

            foreach (var vagrantMachine in vagrantMachines)
            {
                var response = _vagrantSshCommand.StartProcess(_vagrantSshCommandRequestBuilderFactory.Factory()
                    .BaseBuilder
                    .UsingTimeout(request.BaseCommand.Timeout)
                    .UsingWorkingDirectory(request.BaseCommand.WorkingDirectory)
                    .Parent<ISshCommandRequestBuilder>()
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