#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;
using Frenchex.Dev.Vos.Cli.Integration.Domain.Options;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Provision;

public class ProvisionCommandIntegration : ABaseCommandIntegration, IProvisionCommandIntegration
{
    private readonly IProvisionCommand _command;
    private readonly IProvisionCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;

    public ProvisionCommandIntegration(
        IProvisionCommand command,
        IProvisionCommandRequestBuilderFactory requestBuilderFactory,
        INamesArgumentBuilder namesArgumentBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _requestBuilderFactory = requestBuilderFactory;
        _namesArgumentBuilder = namesArgumentBuilder;
    }

    public void IntegrateInto(Command parentCommand)
    {
        Argument<string[]>? namesArg = _namesArgumentBuilder.Build();
        Option<string[]> provisionWithOpt = new(new[] { "--provision-with" }, "Provision with");

        Option<string>? timeout = TimeoutStrOptionBuilder.Build();
        Option<string>? workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        Option<string>? vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("provision", "Runs Vagrant provision")
        {
            namesArg,
            provisionWithOpt,
            timeout,
            workingDirOpt,
            vagrantBinPath
        };

        var binder = new ProvisionCommandIntegrationPayloadBinder(
            namesArg,
            provisionWithOpt,
            timeout,
            workingDirOpt,
            vagrantBinPath
        );

        command.SetHandler(async context =>
        {
            var payload = binder.GetBoundValue(context);
            var requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            var response = await _command
                    .ExecuteAsync(requestBuilder
                        .UsingNames(payload.Names!.ToArray())
                        .UsingProvisionWith(payload.ProvisionWith!)
                        .Build()
                    )
                ;

            if (null == response.Response.ProcessExecutionResult.WaitForCompleteExit)
                throw new InvalidOperationException("missing response elements");

            response.Response.Process.WrappedProcess.OutputDataReceived += (_, args) =>
            {
                if (args.Data != null) context.Console.Out.Write(args.Data + "\r\n");
            };

            Console.CancelKeyPress += delegate
            {
                Console.WriteLine("Cancel key pressed. Cleaning...");
                response.Response.Process.Stop();
                Console.WriteLine("Exiting");
            };

            await response.Response.ProcessExecutionResult.WaitForCompleteExit;
        });

        parentCommand.AddCommand(command);
    }
}