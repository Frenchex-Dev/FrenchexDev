using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Request;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.SshConfig;

public class SshConfigCommandIntegration : ABaseCommandIntegration, ISshConfigCommandIntegration
{
    private readonly ISshConfigCommand _command;
    private readonly IExtraSshArgsOptionBuilder _extraSshArgsOptionBuilder;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IPlainTextOptionBuilder _plainTextOptionBuilder;
    private readonly ISshConfigCommandRequestBuilderFactory _requestBuilderFactory;

    public SshConfigCommandIntegration(
        ISshConfigCommand command,
        ISshConfigCommandRequestBuilderFactory requestBuilderFactory,
        INamesArgumentBuilder namesArgumentBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder,
        IPlainTextOptionBuilder plainTextOptionBuilder,
        IExtraSshArgsOptionBuilder extraSshArgsOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _namesArgumentBuilder = namesArgumentBuilder;
        _plainTextOptionBuilder = plainTextOptionBuilder;
        _extraSshArgsOptionBuilder = extraSshArgsOptionBuilder;
    }

    public void IntegrateInto(Command parentCommand)
    {
        Argument<string[]> namesOrIdsOpt = _namesArgumentBuilder.Build();
        Option<string> workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        Option<String> timeOutMsOpt = TimeoutStrOptionBuilder.Build();
        Option<bool> color = new(new[] {"--color"}, "Color");
        Option<string> vagrantBinPathOpt = VagrantBinPathOptionBuilder.Build();
        Option<string> extraSshArgsOpt = _extraSshArgsOptionBuilder.Build();
        Option<bool> plain = _plainTextOptionBuilder.Build();

        var command = new Command("ssh-config", "Runs Vagrant ssh-config") {
            namesOrIdsOpt,
            workingDirOpt,
            timeOutMsOpt,
            color,
            vagrantBinPathOpt,
            extraSshArgsOpt,
            plain
        };

        var binder = new SshConfigCommandIntegrationPayloadBinder(
            namesOrIdsOpt,
            workingDirOpt,
            timeOutMsOpt,
            vagrantBinPathOpt,
            plain,
            extraSshArgsOpt,
            color
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);

            await _command
                    .ExecuteAsync(_requestBuilderFactory.Factory()
                        .BaseBuilder
                        .UsingTimeout(payload.TimeoutString)
                        .UsingWorkingDirectory(payload.WorkingDirectory)
                        .UsingVagrantBinPath(payload.VagrantBinPath)
                        .WithColor(payload.WithColor ?? false)
                        .Parent<SshConfigCommandRequestBuilder>()
                        .UsingNamesOrIds(payload.NamesOrIds ?? Array.Empty<string>())
                        .Build()
                    )
                ;
        });

        parentCommand.AddCommand(command);
    }
}