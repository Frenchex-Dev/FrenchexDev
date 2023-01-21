#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Status;

public class StatusCommandIntegration : ABaseCommandIntegration, IStatusCommandIntegration
{
    private readonly IStatusCommand _command;
    private readonly IConsole _console;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IStatusCommandRequestBuilderFactory _requestBuilderFactory;

    public StatusCommandIntegration(
        IStatusCommand command,
        IStatusCommandRequestBuilderFactory requestBuilderFactory,
        INamesArgumentBuilder namesArgumentBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder,
        IConsole console
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _namesArgumentBuilder = namesArgumentBuilder;
        _console = console;
    }

    public void IntegrateInto(Command parentCommand)
    {
        var nameArg = _namesArgumentBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        var timeoutOpt = TimeoutStrOptionBuilder.Build();
        var vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("status", "Runs Vagrant status")
        {
            nameArg,
            workingDirOpt,
            timeoutOpt,
            vagrantBinPath
        };

        var binder = new StatusCommandIntegrationPayloadBinder(nameArg, workingDirOpt, timeoutOpt);

        command.SetHandler(async context =>
        {
            StatusCommandIntegrationPayload? payload = binder.GetBoundValue(context);
            IStatusCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            IStatusCommandResponse? response = await _command.ExecuteAsync(requestBuilder
                .WithNames(payload.Names!)
                .Build()
            );

            foreach (var status in response.Statuses) Console.WriteLine($"{status.Value.Item1} : {status.Value.Item2}");
        });

        parentCommand.AddCommand(command);
    }
}