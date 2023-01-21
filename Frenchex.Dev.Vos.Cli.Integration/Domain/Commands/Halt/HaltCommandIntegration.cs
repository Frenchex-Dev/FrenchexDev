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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Commands.Halt;

public class HaltCommandIntegration : ABaseCommandIntegration, IHaltCommandIntegration
{
    private readonly IHaltCommand _command;
    private readonly IForceOptionBuilder _forceOptionBuilder;
    private readonly INamesArgumentBuilder _namesArgumentBuilder;
    private readonly IHaltCommandRequestBuilderFactory _responseBuilderFactory;

    public HaltCommandIntegration(
        IHaltCommand command,
        IHaltCommandRequestBuilderFactory responseBuilder,
        INamesArgumentBuilder namesArgumentBuilder,
        IForceOptionBuilder forceOptionBuilder,
        ITimeoutMsOptionBuilder timeoutStrOptionBuilder,
        IWorkingDirectoryOptionBuilder workingDirectoryOptionBuilder,
        IVagrantBinPathOptionBuilder vagrantBinPathOptionBuilder
    ) : base(workingDirectoryOptionBuilder, timeoutStrOptionBuilder, vagrantBinPathOptionBuilder)
    {
        _command = command;
        _responseBuilderFactory = responseBuilder;
        _namesArgumentBuilder = namesArgumentBuilder;
        _forceOptionBuilder = forceOptionBuilder;
    }

    public void IntegrateInto(Command parentCommand)
    {
        var namesArg = _namesArgumentBuilder.Build();
        var forceOpt = _forceOptionBuilder.Build();
        var haltTimeoutStrOpt = TimeoutStrOptionBuilder.Build(
            new[] { "--halt-timeoutms" },
            () => "10s",
            "Halt timeout"
        );

        var timeoutMsOpt = TimeoutStrOptionBuilder.Build("10s");
        var workingDirOpt = WorkingDirectoryOptionBuilder.Build();
        var vagrantBinPath = VagrantBinPathOptionBuilder.Build();

        var command = new Command("halt", "Runs Vagrant halt")
        {
            namesArg,
            forceOpt,
            haltTimeoutStrOpt,
            timeoutMsOpt,
            workingDirOpt,
            vagrantBinPath
        };

        var binder = new HaltCommandIntegrationPayloadBinder(
            namesArg,
            forceOpt,
            haltTimeoutStrOpt,
            timeoutMsOpt,
            workingDirOpt,
            vagrantBinPath
        );

        command.SetHandler(async context =>
        {
            HaltCommandIntegrationPayload payload = binder.GetBoundValue(context);
            IHaltCommandRequestBuilder requestBuilder = _responseBuilderFactory.Factory();

            BuildBase(requestBuilder, payload);

            IHaltCommandResponse response = await _command.ExecuteAsync(requestBuilder
                    .UsingNames(payload.Names)
                    .WithForce(payload.Force)
                    .UsingHaltTimeout(payload.HaltTimeout)
                    .Build()
                )
                ;

            if (null == response.Response.ProcessExecutionResult.WaitForCompleteExit)
                throw new InvalidOperationException("missing response elements");

            response.Response.Process.WrappedProcess.OutputDataReceived += (sender, args) =>
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