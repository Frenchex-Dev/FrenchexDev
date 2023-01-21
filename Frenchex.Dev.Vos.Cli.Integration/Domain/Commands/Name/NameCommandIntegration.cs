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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

#endregion

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
        var nameArg = _namesArgumentBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        var timeoutOpt = TimeoutStrOptionBuilder.Build();

        var command = new Command("name", "Output Vagrant machine names")
        {
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
            NameCommandIntegrationPayload? payload = binder.GetBoundValue(context);
            INameCommandRequestBuilder? requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            INameCommandResponse? response = await _command.ExecuteAsync(requestBuilder
                .WithNames(payload.Names!)
                .Build()
            );

            foreach (string? name in response.Names) Console.Write(name);
        });

        parentCommand.AddCommand(command);
    }
}