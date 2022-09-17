﻿using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Ssh;

public class SshCommandIntegration : ABaseCommandIntegration, ISshCommandIntegration
{
    private readonly ISshCommand _command;
    private readonly ICommandsOptionBuilder _commandsOptionBuilder;
    private readonly IExtraSshArgsOptionBuilder _extraSshArgsOptionBuilder;
    private readonly INamesOptionBuilder _namesOptionBuilder;
    private readonly IPlainTextOptionBuilder _plainTextOptionBuilder;
    private readonly ISshCommandRequestBuilderFactory _requestBuilderFactory;

    public SshCommandIntegration(
        ISshCommand command,
        ISshCommandRequestBuilderFactory requestBuilderFactory,
        INamesOptionBuilder namesOptionBuilder,
        ITimeoutMsOptionBuilder timeoutMsOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder,
        ICommandsOptionBuilder commandsOptionBuilder,
        IPlainTextOptionBuilder plainTextOptionBuilder,
        IExtraSshArgsOptionBuilder extraSshArgsOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutMsOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _namesOptionBuilder = namesOptionBuilder;
        _commandsOptionBuilder = commandsOptionBuilder;
        _plainTextOptionBuilder = plainTextOptionBuilder;
        _extraSshArgsOptionBuilder = extraSshArgsOptionBuilder;
    }

    public void Integrate(Command parentCommand)
    {
        Option<string[]> namesOpts = _namesOptionBuilder.Build();
        Option<string[]> commandsOpt = _commandsOptionBuilder.Build();
        Option<bool> plainTextOpt = _plainTextOptionBuilder.Build();
        Option<string> extraSshArgsOpt = _extraSshArgsOptionBuilder.Build();
        Option<int> timeOutMsOpt = TimeoutMsOptionBuilder.Build();
        Option<string> vagrantBinPath = VagrantBinPathOptionBuilder.Build();
        Option<string> workingDir = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("ssh", "Runs ssh command") {
            namesOpts,
            commandsOpt,
            timeOutMsOpt,
            vagrantBinPath,
            workingDir,
            plainTextOpt,
            extraSshArgsOpt
        };

        var binder = new SshCommandIntegrationPayloadBinder(
            namesOpts,
            commandsOpt,
            timeOutMsOpt,
            vagrantBinPath,
            workingDir,
            plainTextOpt,
            extraSshArgsOpt
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _requestBuilderFactory.Factory();
            var request = requestBuilder
                .BaseBuilder
                .UsingWorkingDirectory(payload.WorkingDirectory)
                .UsingTimeoutMs(payload.TimeoutMs ?? 0)
                .UsingVagrantBinPath(payload.VagrantBinPath)
                .Parent<SshCommandRequestBuilder>()
                .UsingCommands(payload.Commands ?? Array.Empty<string>())
                .UsingNames(payload.NamesOrIds!)
                .Build();

            await _command.Execute(request);

            context.ExitCode = 0;
        });

        parentCommand.AddCommand(command);
    }
}