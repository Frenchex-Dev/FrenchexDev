﻿using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Name;

public class NameCommandIntegration : ABaseCommandIntegration, INameCommandIntegration
{
    private readonly INameCommand _command;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly INameCommandRequestBuilderFactory _requestBuilderFactory;

    public NameCommandIntegration(
        INameCommand command,
        INameCommandRequestBuilderFactory requestBuilderFactory,
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
        Option<string> timeoutOpt = TimeoutStrOptionBuilder.Build();

        var command = new Command("name", "Output Vagrant machine names") {
            nameArg,
            timeoutOpt,
            workingDirOpt
        };

        var binder = new NameCommandIntegrationPayloadBinder(
            nameArg,
            timeoutOpt,
            workingDirOpt
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            var response = await _command.ExecuteAsync(requestBuilder
                .WithNames(payload.Names!)
                .Build()
            );

            foreach (var name in response.Names)
            {
                Console.Write(name);
            }
        });

        parentCommand.AddCommand(command);
    }
}