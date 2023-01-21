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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Response;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Provision;

public class ProvisionCommandIntegration : ABaseCommandIntegration, IProvisionCommandIntegration
{
    private readonly IProvisionCommand _command;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IProvisionCommandRequestBuilderFactory _requestBuilderFactory;

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
        var namesArg = _namesArgumentBuilder.Build();
        var provisionWithOpt = new Option<string[]>(new[] { "--provision-with" }, "Provision with");

        var timeout = TimeoutStrOptionBuilder.Build();
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        var vagrantBinPath = VagrantBinPathOptionBuilder.Build();

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
            ProvisionCommandIntegrationPayload payload = binder.GetBoundValue(context);
            IProvisionCommandRequestBuilder requestBuilder = _requestBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            IProvisionCommandResponse response = await _command
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