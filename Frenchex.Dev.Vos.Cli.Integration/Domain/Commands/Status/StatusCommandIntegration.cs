using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Status;

public class StatusCommandIntegration : ABaseCommandIntegration, IStatusCommandIntegration
{
    private readonly IStatusCommand _command;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IStatusCommandRequestBuilderFactory _requestBuilderFactory;

    public StatusCommandIntegration(
        IStatusCommand command,
        IStatusCommandRequestBuilderFactory requestBuilderFactory,
        INamesArgumentBuilder namesArgumentBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _namesArgumentBuilder = namesArgumentBuilder;
    }

    public void IntegrateInto(Command parentCommand)
    {
        Argument<string[]> nameArg = _namesArgumentBuilder.Build();
        Option<string> workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        Option<String> timeoutOpt = TimeoutStrOptionBuilder.Build();
        Option<string> vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("status", "Runs Vagrant status") {
            nameArg,
            workingDirOpt,
            timeoutOpt,
            vagrantBinPath
        };

        var binder = new StatusCommandIntegrationPayloadBinder(nameArg, workingDirOpt, timeoutOpt);

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            await _command.ExecuteAsync(requestBuilder
                .WithNames(payload.Names!)
                .Build()
            );
        });

        parentCommand.AddCommand(command);
    }
}