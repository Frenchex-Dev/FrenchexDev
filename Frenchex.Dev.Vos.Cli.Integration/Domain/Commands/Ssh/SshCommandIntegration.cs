#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Request;

#endregion

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
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder,
        ICommandsOptionBuilder commandsOptionBuilder,
        IPlainTextOptionBuilder plainTextOptionBuilder,
        IExtraSshArgsOptionBuilder extraSshArgsOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _namesOptionBuilder = namesOptionBuilder;
        _commandsOptionBuilder = commandsOptionBuilder;
        _plainTextOptionBuilder = plainTextOptionBuilder;
        _extraSshArgsOptionBuilder = extraSshArgsOptionBuilder;
    }

    public void IntegrateInto(Command parentCommand)
    {
        var namesOpts = _namesOptionBuilder.Build();
        var commandsOpt = _commandsOptionBuilder.Build();
        var plainTextOpt = _plainTextOptionBuilder.Build();
        var extraSshArgsOpt = _extraSshArgsOptionBuilder.Build();
        var timeOutStrOpt = TimeoutStrOptionBuilder.Build();
        var vagrantBinPath = VagrantBinPathOptionBuilder.Build();
        var workingDir = WorkingDirectoryOptionBuilder.Build();

        var command = new Command("ssh", "Runs ssh command")
        {
            namesOpts,
            commandsOpt,
            timeOutStrOpt,
            vagrantBinPath,
            workingDir,
            plainTextOpt,
            extraSshArgsOpt
        };

        var binder = new SshCommandIntegrationPayloadBinder(
            namesOpts,
            commandsOpt,
            timeOutStrOpt,
            vagrantBinPath,
            workingDir,
            plainTextOpt,
            extraSshArgsOpt
        );

        command.SetHandler(async context =>
        {
            SshCommandIntegrationPayload? payload = binder.GetBoundValue(context);
            ISshCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();
            ISshCommandRequest? request = requestBuilder
                .BaseBuilder
                .UsingWorkingDirectory(payload.WorkingDirectory)
                .UsingTimeout(payload.TimeoutString)
                .UsingVagrantBinPath(payload.VagrantBinPath)
                .Parent<SshCommandRequestBuilder>()
                .UsingCommands(payload.Commands ?? Array.Empty<string>())
                .UsingNames(payload.NamesOrIds!)
                .Build();

            await _command.ExecuteAsync(request);

            context.ExitCode = 0;
        });

        parentCommand.AddCommand(command);
    }
}